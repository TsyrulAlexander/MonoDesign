using System;
using System.Windows.Input;
using MonoDesign.Engine;
using MonoDesign.UI.Component.Command;
using MonoDesign.UI.Component.Dialog;
using MonoDesign.UI.Component.Entity;
using MonoDesign.UI.Component.Property;

namespace MonoDesign.UI.ViewModel
{
	public class CreateProjectViewModel : Core.VM.ViewModel, IModalViewModel<CreateProjectInfo, CreateProjectInfoResult> {
		public event Action<CreateProjectInfoResult> Completed;
		private readonly IDialogService _dialogService;
		public StringProperty Name { get; set; }
		public StringProperty Directory { get; set; }
		public ICommand CreateCommand => new RelayCommand(CreateExecute, CreateCanExecute);
		private bool CreateCanExecute() {
			return (Name?.IsValid(out _) ?? false) && (Directory?.IsValid(out _) ?? false);
		}
		public ICommand SelectDirectoryCommand => new RelayCommand(SelectDirectoryExecute);
		public CreateProjectViewModel(IDialogService dialogService) {
			_dialogService = dialogService;
		}
		public override void Initialize() {
			base.Initialize();
			Name = new StringProperty("Name", true);
			Directory = new StringProperty("Directory", true);
		}
		private void CreateExecute() {
			OnCompleted(new CreateProjectInfoResult {
				Name = Name.Value,
				Directory = Directory.Value
			});
		}
		private void SelectDirectoryExecute() {
			var path = _dialogService.SelectFolder(Directory.Value);
			if (string.IsNullOrWhiteSpace(path)) {
				return;
			}
			Directory.Value = path;
		}
		public void SetValue(CreateProjectInfo value) {
			
		}
		protected virtual void OnCompleted(CreateProjectInfoResult obj) {
			Completed?.Invoke(obj);
		}
	}
}
