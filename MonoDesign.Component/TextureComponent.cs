using System.ComponentModel;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Component.Attribute;
using MonoDesign.Core;
using MonoDesign.Core.Entity.GameObject;
using MonoDesign.Core.Serialization;
using MonoDesign.Core.Utilities;
using MonoDesign.Engine;

namespace MonoDesign.Component
{
	[GameSerializable]
	[Component("Texture")]
	public class TextureComponent : BaseComponent {
		private DesignEngine _designEngine;
		private string _textureName;
		public string TextureName {
			get => _textureName;
			set {
				if (value == _textureName)
					return;
				_textureName = value;
				LoadTexture();
				OnPropertyChanged();
			}
		}
		public Texture2D Texture {
			get => GameObject.Texture;
			protected set {
				if (Equals(value, GameObject.Texture))
					return;
				GameObject.Texture = value;
				OnPropertyChanged();
			}
		}
		public TextureComponent(DesignEngine designEngine) {
			_designEngine = designEngine;
		}
		public override void Initialize(IGameObject gameObject) {
			base.Initialize(gameObject);
			gameObject.PropertyChanged += GameObjectOnPropertyChanged;
			_designEngine = _designEngine ?? GameServices.GetService<DesignEngine>();
		}
		private void GameObjectOnPropertyChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == nameof(GameObject.Texture)) {
				OnPropertyChanged(nameof(Texture));
			}
		}
		public override void Serialize(object obj, SerializationInfo info, StreamingContext context) {
			base.Serialize(obj, info, context);
			var item = (TextureComponent)obj;
			info.Serialize(item, component => component.TextureName);
			info.Serialize(item, component => component.IsDrawable);
			info.Serialize(item, component => component.IsUpdatable);
		}
		public override object Deserialize(object obj, SerializationInfo info, StreamingContext context) {
			var item = (TextureComponent)obj;
			info.Deserialize(item, component => component.TextureName);
			info.Deserialize(item, component => component.IsUpdatable);
			info.Deserialize(item, component => component.IsDrawable);
			return base.Deserialize(item, info, context);
		}
		public override void OnDeserialized() {
			base.OnDeserialized();
			LoadTexture();
		}
		protected virtual void LoadTexture() {
			if (GameObject == null) {
				return;
			}
			Texture = _designEngine?.LoadTexture(_textureName);
		}
	}
}
