using System.Collections.Generic;

namespace MonoDesign.Core.Entity.Component {
	public interface IComponent {
		IEnumerable<IGameObjectComponent> GetComponents();
		void AddComponent(IGameObjectComponent component);
		void RemoveComponent(IGameObjectComponent component);
	}
}