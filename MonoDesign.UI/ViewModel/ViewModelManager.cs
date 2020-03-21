using MonoDesign.Core;
using MonoDesign.UI.ViewModel.Component;

namespace MonoDesign.UI.ViewModel
{
	public class ViewModelManager {
		public static GameObjectListViewModel GameObjectList => CreateViewModel<GameObjectListViewModel>();
		public static ViewPortViewModel ViewPort => CreateViewModel<ViewPortViewModel>();
		public static CommandViewModel Command => CreateViewModel<CommandViewModel>();
		public static CreateProjectViewModel CreateProject => CreateViewModel<CreateProjectViewModel>();
		public static SceneListViewModel SceneList => CreateViewModel<SceneListViewModel>();
		public static GameObjectPropertyViewModel GameObjectProperty => CreateViewModel<GameObjectPropertyViewModel>();
		public static PositionComponentViewModel PositionComponent => CreateViewModel<PositionComponentViewModel>();
		public static TextureComponentViewModel TextureComponent => CreateViewModel<TextureComponentViewModel>();
		public static ScriptComponentViewModel ScriptComponent => CreateViewModel<ScriptComponentViewModel>();
		public static T CreateViewModel<T>() where T : Core.VM.ViewModel {
			var viewModel = GameServices.GetService<T>();
			viewModel.Initialize();
			return viewModel;
		}
	}
}
