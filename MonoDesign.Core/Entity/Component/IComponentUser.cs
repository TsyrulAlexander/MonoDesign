using System.Collections.ObjectModel;

namespace MonoDesign.Core.Entity.Component {
	public interface IComponentUser {
		ObservableCollection<IGameObjectComponent> Components { get; set; }
		void AddComponent(IGameObjectComponent component);
		void RemoveComponent(IGameObjectComponent component);
	}
}