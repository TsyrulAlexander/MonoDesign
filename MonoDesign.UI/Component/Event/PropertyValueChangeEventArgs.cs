using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDesign.UI.Component.Event {
	public class PropertyValueChangeEventArgs<T> : System.EventArgs {
		public T OldValue { get; }
		public T NewValue { get; }

		public PropertyValueChangeEventArgs(T oldValue, T newValue) {
			OldValue = oldValue;
			NewValue = newValue;
		}
	}
}