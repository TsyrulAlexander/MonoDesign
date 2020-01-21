using System.ComponentModel;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Core.Entity.GameObject;
using MonoDesign.Core.Serialization;
using MonoDesign.Core.Utilities;

namespace MonoDesign.Core.Entity.Component
{
	[GameSerializable]
	public class TextureComponent : BaseComponent {
		public string TextureName { get; set; }
		public Texture2D Texture {
			get => GameObject.Texture;
			set {
				if (Equals(value, GameObject.Texture))
					return;
				GameObject.Texture = value;
				OnPropertyChanged();
			}
		}
		public override void Initialize(IGameObject gameObject) {
			base.Initialize(gameObject);
			gameObject.PropertyChanged += GameObjectOnPropertyChanged;
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
	}
}
