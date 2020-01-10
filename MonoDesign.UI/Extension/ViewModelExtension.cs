using MonoDesign.Core;
using MonoDesign.UI.ViewModel;

namespace MonoDesign.UI.Extension {
	public static class ViewModelExtension {
		public static void UseViewModel(this ServiceProvider provider) {
			provider.AddTransient<GameObjectListViewModel, GameObjectListViewModel>();
			provider.AddTransient<ViewPortViewModel, ViewPortViewModel>();
		}
	}
}