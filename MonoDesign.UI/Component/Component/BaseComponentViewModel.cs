using MonoDesign.Core.Entity.Component;

namespace MonoDesign.UI.Component.Component
{
	public abstract class BaseComponentViewModel<T> : Core.VM.ViewModel, IComponentViewModel<T> where T : IGameObjectComponent {
		private T _value;
		public virtual T Value {
			get => _value;
			set {
				if (Equals(value, _value))
					return;
				_value = value;
				OnPropertyChanged();
			}
		}
		public virtual void SetValue(object value) {
			Value = (T)value;
		}
	}
}
