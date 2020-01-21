using System;
using MonoDesign.UI.Component.Event;

namespace MonoDesign.UI.Component.Property {
	public abstract class BaseProperty<T> : BaseProperty {

		private T _value;
		public T Value {
			get => _value;
			set {
				OnPropertyValueChange(new PropertyValueChangeEventArgs<T>(_value, value));
				_value = value;
				OnPropertyChanged();
			}
		}

		public event Action<PropertyValueChangeEventArgs<T>> PropertyValueChange;

		protected BaseProperty(string caption, bool isRequired = false, object tag = null) : base(caption, isRequired,
			tag) {
		}

		public override string ToString() {
			return Value.ToString();
		}

		protected virtual void OnPropertyValueChange(PropertyValueChangeEventArgs<T> eventArgs) {
			PropertyValueChange?.Invoke(eventArgs);
		}
	}
}