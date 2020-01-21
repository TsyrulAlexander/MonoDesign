using System;

namespace MonoDesign.Core.Entity.Reflection {
	public class AttributeInfo<T> where T : Attribute {
		public T Attribute { get; set; }
		public Type Type { get; set; }
		public AttributeInfo(T attribute, Type type) {
			Attribute = attribute;
			Type = type;
		}
	}
}