using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Core.Entity.GameObject;
using MonoDesign.Core.Serialization;
using MonoDesign.Core.Utilities;

namespace MonoDesign.Core.Entity.Scene {
	[GameSerializable]
	public class Scene: IGameSerializable, ILookup {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public SpriteSortMode SortMode { get; set; } = SpriteSortMode.Deferred;
		public BlendState BlendState { get; set; }
		public SamplerState SamplerState { get; set; }
		public DepthStencilState DepthStencilState { get; set; }
		public RasterizerState RasterizerState { get; set; }
		public Effect Effect { get; set; }
		public Matrix? TransformMatrix { get; set; }
		public ObservableCollection<IGameObject> GameObjects { get; private set; } = new ObservableCollection<IGameObject>();
		public void Serialize(object obj, SerializationInfo info, StreamingContext context) {
			var item = (Scene)obj;
			info.Serialize(item, scene => scene.Id);
			info.Serialize(item, scene => scene.Name);
			info.Serialize(item, scene => scene.GameObjects);
		}
		public object Deserialize(object obj, SerializationInfo info, StreamingContext context) {
			var item = (Scene)obj;
			info.Deserialize(item, scene => scene.Id);
			info.Deserialize(item, scene => scene.Name);
			info.Deserialize(item, scene => scene.GameObjects);
			return item;
		}
		public void OnSerialized() {
			foreach (var gameObject in GameObjects) {
				gameObject.OnSerialized();
			}
		}
		public void OnDeserialized() {
			foreach (var gameObject in GameObjects) {
				gameObject.Initialize();
				gameObject.OnDeserialized();
			}
		}
	}
}
