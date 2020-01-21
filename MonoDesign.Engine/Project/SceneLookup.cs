using System;
using System.Runtime.Serialization;
using MonoDesign.Core.Entity;
using MonoDesign.Core.Serialization;
using MonoDesign.Core.Utilities;

namespace MonoDesign.Engine.Project {
	[GameSerializable]
	public class SceneLookup : IGameSerializable, ILookup {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public void Serialize(object obj, SerializationInfo info, StreamingContext context) {
			var item = (SceneLookup) obj;
			info.Serialize(item, lookup => lookup.Id);
			info.Serialize(item, lookup => lookup.Name);
		}
		public object Deserialize(object obj, SerializationInfo info, StreamingContext context) {
			var item = (SceneLookup)obj;
			info.Deserialize(item, lookup => lookup.Id);
			info.Deserialize(item, lookup => lookup.Name);
			return item;
		}
		public virtual void OnSerialized() { }
		public virtual void OnDeserialized() { }
		public static SceneLookup Create(Core.Entity.Scene.Scene scene) {
			return new SceneLookup {
				Id = scene.Id,
				Name = scene.Name
			};
		}
	}
}