using System.Collections.Generic;
using MonoDesign.Core.Entity.Component;
using MonoDesign.Core.Serialization;

namespace MonoDesign.Core.Entity.GameObject {
	public interface IGameObject : IElement, IComponent, IUpdatable, IDrawable, IGameSerializable {
		string Name { get; set; }
	}
}
