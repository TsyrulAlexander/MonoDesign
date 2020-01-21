using System.ComponentModel;
using System.Windows.Input;
using MonoDesign.Core.Entity.GameObject;
using MonoDesign.Core.Entity.Scene;
using MonoDesign.Core.Messages;
using MonoDesign.Engine;
using MonoDesign.UI.Component.Command;
using MonoDesign.UI.Component.Entity;

namespace MonoDesign.UI.ViewModel {
	public class GameObjectListViewModel : Core.VM.ViewModel {
		private readonly DesignEngine _engine;
		private readonly IMessenger _messenger;
		private ListViewModel<IGameObject> _gameObjectList;
		public ListViewModel<IGameObject> GameObjectList {
			get => _gameObjectList;
			set {
				if (Equals(value, _gameObjectList))
					return;
				_gameObjectList = value;
				OnPropertyChanged();
			}
		}
		public ICommand CreateGameObjectCommand { get; set; }
		public GameObjectListViewModel(DesignEngine engine, IMessenger messenger) {
			_engine = engine;
			_messenger = messenger;
			engine.PropertyChanged += EngineOnPropertyChanged;
			CreateGameObjectCommand = new RelayCommand(CreateGameObjectExecute);
		}
		private void GameObjectListOnPropertyChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == nameof(GameObjectList.CurrentItem)) {
				OnSelectedGameObjectChanged();
			}
		}
		protected virtual void OnSelectedGameObjectChanged() {
			_messenger.Publish("SelectedGameObjectChanged", GameObjectList.CurrentItem);
		}
		private void CreateGameObjectExecute() {
			_engine.CreateGameObject();
		}

		private void EngineOnPropertyChanged(object sender, PropertyChangedEventArgs e) {
			var item = (DesignEngine)sender;
			if (e.PropertyName == nameof(item.CurrentScene)) {
				EngineOnSceneChange(item.CurrentScene);
			}
		}
		public override void Initialize() {
			base.Initialize();
			InitGameObjectList(_engine.CurrentScene);
		}
		protected virtual void EngineOnSceneChange(Scene scene) {
			InitGameObjectList(scene);
		}
		protected virtual void InitGameObjectList(Scene scene) {
			GameObjectList?.Clear();
			if (scene == null) {
				return;
			}
			var currentScene = _engine?.CurrentScene;
			if (currentScene == null) {
				return;
			}
			GameObjectList = new ListViewModel<IGameObject>(currentScene.GameObjects);
			GameObjectList.PropertyChanged += GameObjectListOnPropertyChanged;
		}
	}
}