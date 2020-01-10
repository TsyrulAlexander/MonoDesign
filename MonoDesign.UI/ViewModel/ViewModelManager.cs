using MonoDesign.Core;

namespace MonoDesign.UI.ViewModel
{
	public class ViewModelManager {
		public static GameObjectListViewModel GameObjectList => GameServices.GetService<GameObjectListViewModel>();
		public static ViewPortViewModel ViewPort => GameServices.GetService<ViewPortViewModel>();
	}
}
