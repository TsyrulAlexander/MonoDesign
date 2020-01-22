using System.Linq;
using System.Windows.Input;
using MonoDesign.Engine;
using MonoDesign.UI.Component.Command;
using MonoDesign.UI.Component.Dialog;
using MonoDesign.UI.Component.Entity;

namespace MonoDesign.UI.ViewModel {
	public class CommandViewModel : Core.VM.ViewModel {
		private readonly DesignEngine _designEngine;
		private readonly IDialogService _dialogService;
		public ICommand CreateProjectCommand { get; }
		public ICommand OpenProjectCommand { get; }
		public ICommand SaveProjectCommand { get; }
		public ICommand BuildProjectCommand { get; }
		public CommandViewModel(DesignEngine designEngine, IDialogService dialogService) {
			_designEngine = designEngine;
			_dialogService = dialogService;
			CreateProjectCommand = new RelayCommand(CreateProjectExecute);
			OpenProjectCommand = new RelayCommand(OpenProjectExecute);
			SaveProjectCommand = new RelayCommand(SaveProjectExecute);
			BuildProjectCommand = new RelayCommand(BuildProjectExecute);
		}
		private void BuildProjectExecute() {
			_designEngine.BuildProject();
		}
		private void SaveProjectExecute() {
			_designEngine.SaveProject();
			_designEngine.SaveScene();
		}
		private void OpenProjectExecute() {
			var projectFile = _dialogService.SelectFile("Project file|*.info");
			if (string.IsNullOrWhiteSpace(projectFile)) {
				return;
			}
			_designEngine.LoadProject(projectFile);
			var firstScene = _designEngine.ProjectInfo.Scenes.FirstOrDefault();
			if (firstScene == null) {
				return;
			}
			_designEngine.LoadScene(firstScene);
		}
		private void CreateProjectExecute() {
			_dialogService.ShowModal<CreateProjectInfo, CreateProjectInfoResult>(new CreateProjectInfo(), OnCreateProject);
		}
		protected virtual void OnCreateProject(CreateProjectInfoResult result) {
			_designEngine.CreateProject(result.Directory, result.Name);
			_designEngine.SaveProject();
			_designEngine.CreateScene();
			_designEngine.SaveScene();
			_designEngine.SaveProject();
		} 
	}
}
