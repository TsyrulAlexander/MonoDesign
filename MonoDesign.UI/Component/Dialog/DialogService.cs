using System;
using System.Windows.Forms;
using System.Windows.Threading;
using MonoDesign.Core;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace MonoDesign.UI.Component.Dialog {
	public class DialogService : IDialogService {
		public void ShowModal<T, TResult>(T value, Action<TResult> callback) {
			var modalView = GameServices.GetService<IModalView<T, TResult>>();
			var dispatcher = Dispatcher.CurrentDispatcher;
			modalView.Show(value, result => {
				dispatcher.Invoke(() => {
					callback(result);
				});
			});
		}
		public string SelectFolder(string path) {
			using (var dialog = new FolderBrowserDialog()) {
				dialog.SelectedPath = path;
				var result = dialog.ShowDialog();
				if (result == DialogResult.OK) {
					return dialog.SelectedPath;
				}
			}
			return null;
		}
		public string SaveFile(string directory = "", string filter = "") {
			var dialog = new SaveFileDialog();
			if (string.IsNullOrWhiteSpace(directory)) {
				directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			}
			dialog.InitialDirectory = directory;
			dialog.Filter = filter;
			if (dialog.ShowDialog() == true) {
				return dialog.FileName;
			}
			return null;
		}

		public string SelectFile(string filter = "") {
			var dialog = new OpenFileDialog {
				Filter = filter
			};
			if (dialog.ShowDialog() == true) {
				return dialog.FileName;
			}
			return null;
		}
	}
}
