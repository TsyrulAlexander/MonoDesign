using System;
using MonoDesign.UI.Component.Dialog;
using MonoDesign.UI.Component.Entity;
using MonoDesign.UI.Component.UI;

namespace MonoDesign.UI.View.Modal {
	/// <summary>
	/// Interaction logic for CreateProjectView.xaml
	/// </summary>
	public partial class CreateProjectView : ModalBoxView, IModalView<CreateProjectInfo, CreateProjectInfoResult> {
		public CreateProjectView() {
			InitializeComponent();
		}
		public void Show(CreateProjectInfo value, Action<CreateProjectInfoResult> callback) {
			Show<CreateProjectInfo, CreateProjectInfoResult>(value, callback);
		}
	}
}