using System.Collections.Generic;
using System.ComponentModel;
using MonoDesign.Core.Entity.Scene;
using MonoDesign.Core.Serialization;
using IComponent = MonoDesign.Core.Entity.Component.IComponent;

namespace MonoDesign.Core.Entity.GameObject {
	public interface IGameObject : ILookup, IComponent, IUpdatable, IDrawable, IGameSerializable, INotifyPropertyChanged
	{
	}
}
