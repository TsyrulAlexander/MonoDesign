using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using MonoDesign.Core.Entity.Component;
using MonoDesign.Core.Utilities;

namespace MonoDesign.Core.Entity.GameObject {
	public class GameObject : IGameObject {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public List<IGameObjectComponent> Components { get; set; } = new List<IGameObjectComponent>();
		public IEnumerable<IGameObjectComponent> GetComponents() {
			return Components;
		}
		public void AddComponent(IGameObjectComponent component) {
			Components.Add(component);
		}
		public void RemoveComponent(IGameObjectComponent component) {
			Components.Remove(component);
		}
		public void Update(GameTime gameTime) {
			Components.ForEach(component => component.Update(gameTime));
		}
		public void Draw(GameTime gameTime) {
			Components.ForEach(component => component.Draw(gameTime));
		}
		public void Serialize(object obj, SerializationInfo info, StreamingContext context) {
			var item = (GameObject)obj;
			info.Serialize(item, o => o.Id);
			info.Serialize(item, o => o.Name);
		}
		public object Deserialize(object obj, SerializationInfo info, StreamingContext context) {
			var item = (GameObject)obj;
			info.Deserialize(item, o => o.Id);
			info.Deserialize(item, o => o.Name);
			return item;
		}
	}
}