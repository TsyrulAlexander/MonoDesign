using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDesign.UI.Component.Dialog
{
	interface IModalViewModel<T, TResult> {
		event Action<TResult> Completed;
		void SetValue(T value);
	}
}
