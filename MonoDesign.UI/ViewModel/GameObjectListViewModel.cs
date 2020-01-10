using MonoDesign.UI.Entity;

namespace MonoDesign.UI.ViewModel {
	public class GameObjectListViewModel : Core.VM.ViewModel {
		public ListViewModel<GameObjectView> GameObjectList { get; set; } =
			new ListViewModel<GameObjectView>();
		public GameObjectListViewModel() {
			
		}
	}
}