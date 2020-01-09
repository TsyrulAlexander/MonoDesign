using System.Collections.Generic;
using System.Runtime.Serialization;
using MonoDesign.Core.Entity.GameObject;
using MonoDesign.Core.Serialization;
using MonoDesign.Core.Utilities;

namespace MonoDesign.Core.Entity {
	public class Scene: IGameSerializable {
		public string Name { get; set; }
		public List<IGameObject> GameObjects { get; set; } = new List<IGameObject>();
		public void Serialize(object obj, SerializationInfo info, StreamingContext context) {
			var item = (Scene)obj;
			info.Serialize(item, scene => scene.Name);
			info.Serialize(item, scene => scene.GameObjects);
		}
		public object Deserialize(object obj, SerializationInfo info, StreamingContext context) {
			var item = (Scene)obj;
			info.Deserialize(item, scene => scene.Name);
			info.Deserialize(item, scene => scene.GameObjects);
			return item;
		}
	}
}
