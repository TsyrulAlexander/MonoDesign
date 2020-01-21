using MonoDesign.Core;
using MonoDesign.UI.Component.Dialog;
using MonoDesign.UI.Component.Entity;
using MonoDesign.UI.View.Modal;

namespace MonoDesign.UI.Extension {
	public static class ModalExtension {
		public static void UseModal(this ServiceProvider provider) {
			provider.AddTransient<IModalView<CreateProjectInfo, CreateProjectInfoResult>, CreateProjectView>();
		}
	}
}
