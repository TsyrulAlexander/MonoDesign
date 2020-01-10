using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using MonoDesign.Core.Serialization;
using MonoDesign.Core.Utilities;

namespace MonoDesign.Core.Entity.Project {
	[GameSerializable]
	public class ProjectInfo : IGameSerializable, ILookup {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public SceneLookup[] Scenes { get; set; }
		public void Serialize(object obj, SerializationInfo info, StreamingContext context) {
			var item = (ProjectInfo) obj;
			info.Serialize(item, o => o.Id);
			info.Serialize(item, o => o.Name);
			info.Serialize(item, o => o.Scenes);
		}
		public object Deserialize(object obj, SerializationInfo info, StreamingContext context) {
			var item = (ProjectInfo) obj;
			info.Deserialize(item, o => o.Id);
			info.Deserialize(item, o => o.Name);
			info.Deserialize(item, o => o.Scenes);
			return item;
		}
	}
}