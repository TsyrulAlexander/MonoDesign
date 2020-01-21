using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using MonoDesign.Core.Annotations;
using MonoDesign.Core.Entity.GameObject;

namespace MonoDesign.Core.Entity.Component {
	public abstract class BaseComponent : IGameObjectComponent {
		protected virtual IGameObject GameObject { get; set; }
		public virtual bool IsUpdatable { get; set; }
		public virtual void Update(GameTime gameTime) { }
		public virtual bool IsDrawable { get; set; }
		public virtual void Draw(GameTime gameTime) { }
		public virtual void Serialize(object obj, SerializationInfo info, StreamingContext context) { }
		public virtual object Deserialize(object obj, SerializationInfo info, StreamingContext context) {
			return obj;
		}
		public virtual void OnSerialized() { }
		public virtual void OnDeserialized() { }
		public virtual void Initialize(IGameObject gameObject) {
			GameObject = gameObject;
		}
		public event PropertyChangedEventHandler PropertyChanged;
		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
