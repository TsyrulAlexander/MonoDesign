using System.ComponentModel;
using System.Runtime.CompilerServices;
using MonoDesign.Core.Entity.GameObject;
using MonoDesign.UI.Annotations;

namespace MonoDesign.UI.Entity {
	public class GameObjectView : INotifyPropertyChanged {
		public IGameObject GameObject { get; }
		public bool IsSelected { get; set; }
		public GameObjectView(IGameObject gameObject) {
			GameObject = gameObject;
		}
		public event PropertyChangedEventHandler PropertyChanged;
		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
