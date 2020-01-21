using System.ComponentModel;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using MonoDesign.Core.Entity.GameObject;
using MonoDesign.Core.Serialization;
using MonoDesign.Core.Utilities;

namespace MonoDesign.Core.Entity.Component {
	[GameSerializable]
	public class PositionComponent : BaseComponent {
		private Vector2 _initValue;
		public Vector2 Position {
			get => GameObject.Position;
			set {
				if (GameObject.Position == value) {
					return;
				}
				GameObject.Position = value;
				OnPropertyChanged();
			}
		}
		public override void Initialize(IGameObject gameObject) {
			base.Initialize(gameObject);
			gameObject.PropertyChanged += GameObjectOnPropertyChanged;
		}
		private void GameObjectOnPropertyChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == nameof(GameObject.Position)) {
				OnPropertyChanged(nameof(Position));
			}
		}
		public override void Serialize(object obj, SerializationInfo info, StreamingContext context) {
			base.Serialize(obj, info, context);
			var item = (PositionComponent)obj;
			info.Serialize(item.Position, vector2 => vector2.X);
			info.Serialize(item.Position, vector2 => vector2.Y);
			info.Serialize(item, component => component.IsDrawable);
			info.Serialize(item, component => component.IsUpdatable);
		}
		public override object Deserialize(object obj, SerializationInfo info, StreamingContext context) {
			var item = (PositionComponent)obj;
			var x = info.GetValue<Vector2, float>(vector2 => vector2.X, out _);
			var y = info.GetValue<Vector2, float>(vector2 => vector2.Y, out _);
			_initValue = new Vector2(x, y);
			info.Deserialize(item, component => component.IsDrawable);
			info.Deserialize(item, component => component.IsUpdatable);
			return base.Deserialize(item, info, context);
		}
		public override void OnDeserialized() {
			base.OnDeserialized();
			GameObject.Position = _initValue;
		}
	}
}
