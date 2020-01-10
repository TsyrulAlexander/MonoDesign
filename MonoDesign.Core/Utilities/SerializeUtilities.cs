using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using MonoDesign.Core.Serialization;

namespace MonoDesign.Core.Utilities {
	public static class SerializeUtilities {
		public static byte[] SerializeData(this IGameSerializable obj) {
			var binaryFormatter = new BinaryFormatter {
				SurrogateSelector = GetSurrogateSelector()
			};
			using (var memoryStream = new MemoryStream()) {
				binaryFormatter.Serialize(memoryStream, obj);
				return memoryStream.ToArray();
			}
		}
		public static T DeserializeData<T>(this byte[] bytes) where T: IGameSerializable {
			var binaryFormatter = new BinaryFormatter {
				SurrogateSelector = GetSurrogateSelector()
			};
			using (var memoryStream = new MemoryStream(bytes)) {
				return (T)binaryFormatter.Deserialize(memoryStream);
			}
		}
		public static void Serialize<TSource, TProperty>(this SerializationInfo info, TSource obj,
			Expression<Func<TSource, TProperty>> propertyFn) {
			var type = typeof(TSource);
			var property = ReflectionUtilities.GetPropertyInfo(propertyFn);
			var propertyValue = ReflectionUtilities.GetPropertyValue<TProperty>(obj, property);
			info.AddValue($"{type.Name}_{property.Name}", propertyValue);
		}
		public static void Deserialize<TSource, TProperty>(this SerializationInfo info, TSource obj,
			Expression<Func<TSource, TProperty>> propertyFn) {
			var type = typeof(TSource);
			var property = ReflectionUtilities.GetPropertyInfo(propertyFn);
			var propertyType = GetUnderlyingType(property);
			var propertyValue = info.GetValue($"{type.Name}_{property.Name}", propertyType);
			ReflectionUtilities.SetPropertyValue(property, obj, propertyValue);
		}
		public static Type GetUnderlyingType(this MemberInfo member) {
			switch (member.MemberType) {
				case MemberTypes.Event:
					return ((EventInfo) member).EventHandlerType;
				case MemberTypes.Field:
					return ((FieldInfo) member).FieldType;
				case MemberTypes.Method:
					return ((MethodInfo) member).ReturnType;
				case MemberTypes.Property:
					return ((PropertyInfo) member).PropertyType;
				default:
					throw new NotImplementedException(nameof(member));
			}
		}
		public static SurrogateSelector GetSurrogateSelector() {
			var surrogateSelector = new SurrogateSelector();
			foreach (var type in GetSerializeTypes()) {
				surrogateSelector.AddSurrogate(type, new StreamingContext(StreamingContextStates.All),
					new SerializationSurrogate());
			}
			
			return surrogateSelector;
		}
		private static IEnumerable<Type> GetSerializeTypes() {
			return ReflectionUtilities.GetTypesWithAttribute<GameSerializableAttribute>();
		}
	}
}