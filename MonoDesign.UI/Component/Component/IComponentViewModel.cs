using System.ComponentModel;
using MonoDesign.Core.Entity.Component;

namespace MonoDesign.UI.Component.Component
{
	interface IComponentViewModel: INotifyPropertyChanged {
		void SetValue(object value);
	}

	interface IComponentViewModel<T> : IComponentViewModel where T : IGameObjectComponent { }
}
