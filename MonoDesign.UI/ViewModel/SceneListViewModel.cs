using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using MonoDesign.Engine;
using MonoDesign.Engine.Project;
using MonoDesign.UI.Component.Command;
using MonoDesign.UI.Component.Entity;

namespace MonoDesign.UI.ViewModel
{
	public class SceneListViewModel: Core.VM.ViewModel {
		private readonly DesignEngine _designEngine;
		private ListViewModel<SceneLookup> _sceneList;
		public ListViewModel<SceneLookup> SceneList {
			get => _sceneList;
			set {
				if (Equals(value, _sceneList))
					return;
				_sceneList = value;
				OnPropertyChanged();
			}
		}
		public ICommand CreateSceneCommand { get; } 
		public SceneListViewModel(DesignEngine designEngine) {
			_designEngine = designEngine;
			CreateSceneCommand = new RelayCommand(CreateSceneExecute);
			_designEngine.PropertyChanged += DesignEngineOnPropertyChanged;
		}
		protected virtual void DesignEngineOnPropertyChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == nameof(_designEngine.ProjectInfo)) {
				OnCurrentProjectChange();
			}
			if (e.PropertyName == nameof(_designEngine.CurrentScene)) {
				OnCurrentSceneChange();
			}
		}
		protected virtual void OnCurrentProjectChange() {
			SceneList = new ListViewModel<SceneLookup>(_designEngine.ProjectInfo.Scenes);
			SceneList.PropertyChanged += SceneListOnPropertyChanged;
		}
		protected virtual void OnCurrentSceneChange() {
			var currentScene = _designEngine.CurrentScene;
			if (currentScene == null) {
				SceneList.CurrentItem = null;
			} else {
				var currentLookupScene = _designEngine.ProjectInfo.Scenes.First(lookup => lookup.Id == currentScene.Id);
				SceneList.CurrentItem = currentLookupScene;
			}
		}
		protected virtual void SceneListOnPropertyChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == nameof(SceneList.CurrentItem)) {
				SetCurrentScene();
			}
		}
		protected virtual void SetCurrentScene() {
			if (SceneList.CurrentItem.Id == _designEngine.CurrentScene.Id) {
				return;
			}
			_designEngine.LoadScene(SceneList.CurrentItem);
		}
		protected  virtual void CreateSceneExecute() {
			_designEngine.CreateScene();
			_designEngine.SaveScene();
		}
	}
}
