using MonoDesign.Core.Entity.GameObject;
using MonoDesign.Core.Messages;

namespace MonoDesign.UI.ViewModel {
	public class GameObjectPropertyViewModel : Core.VM.ViewModel {
		private readonly IMessenger _messenger;
		private IGameObject _gameObject;
		public IGameObject GameObject {
			get => _gameObject;
			set {
				if (Equals(value, _gameObject))
					return;
				_gameObject = value;
				OnPropertyChanged();
			}
		}
		public GameObjectPropertyViewModel(IMessenger messenger) {
			_messenger = messenger;
		}
		public override void Initialize() {
			base.Initialize();
			_messenger.Subscribe<IGameObject>("SelectedGameObjectChanged", SelectedGameObjectChanged);
		}
		private void SelectedGameObjectChanged(IGameObject obj) {
			GameObject = obj;
		}
	}
}