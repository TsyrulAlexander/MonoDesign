using System;
using System.Windows;
using MonoDesign.UI.Component.Dialog;

namespace MonoDesign.UI.Component.UI {
	public class ModalBoxView : Window {
		public void Show<T, TResult>(T value, Action<TResult> callback) {
			var viewModel = (IModalViewModel<T, TResult>) DataContext;
			viewModel.SetValue(value);
			void Completed(TResult response) {
				viewModel.Completed -= Completed;
				Close();
				callback(response);
			}
			viewModel.Completed += Completed;
			ShowDialog();
		}
	}
}