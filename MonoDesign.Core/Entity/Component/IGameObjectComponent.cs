using System.ComponentModel;
using MonoDesign.Core.Entity.GameObject;
using MonoDesign.Core.Serialization;

namespace MonoDesign.Core.Entity.Component {
	public interface IGameObjectComponent : INotifyPropertyChanged, IUpdatable, IDrawable, IGameSerializable {
		void Initialize(IGameObject gameObject);
	}
}
