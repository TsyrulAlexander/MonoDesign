using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using MonoDesign.Core.Entity;
using MonoDesign.Core.Serialization;
using MonoDesign.Core.Utilities;

namespace MonoDesign.Engine.Project {
	[GameSerializable]
	public class ProjectInfo : IGameSerializable {
		public Guid Id { get; set; }
		public string Name { get; internal set; }
		public string Path { get; internal set; }
		public ObservableCollection<SceneLookup> Scenes { get; set; } = new ObservableCollection<SceneLookup>();
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
		public void OnSerialized() {
			foreach (var sceneLookup in Scenes) {
				sceneLookup.OnSerialized();
			}
		}
		public void OnDeserialized() {
			foreach (var sceneLookup in Scenes) {
				sceneLookup.OnDeserialized();
			}
		}
	}
}