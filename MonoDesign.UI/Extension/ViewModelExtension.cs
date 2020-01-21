using MonoDesign.Core;
using MonoDesign.UI.ViewModel;
using MonoDesign.UI.ViewModel.Component;

namespace MonoDesign.UI.Extension {
	public static class ViewModelExtension {
		public static void UseViewModel(this ServiceProvider provider) {
			provider.AddTransient<GameObjectListViewModel, GameObjectListViewModel>();
			provider.AddTransient<ViewPortViewModel, ViewPortViewModel>();
			provider.AddTransient<CommandViewModel, CommandViewModel>();
			provider.AddTransient<CreateProjectViewModel, CreateProjectViewModel>();
			provider.AddTransient<SceneListViewModel, SceneListViewModel>();
			provider.AddTransient<GameObjectPropertyViewModel, GameObjectPropertyViewModel>();
			provider.AddTransient<PositionComponentViewModel, PositionComponentViewModel>();
			provider.AddTransient<TextureComponentViewModel, TextureComponentViewModel>();

		}
	}
}