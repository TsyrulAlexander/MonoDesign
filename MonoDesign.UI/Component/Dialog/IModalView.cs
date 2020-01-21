using System;

namespace MonoDesign.UI.Component.Dialog {
	interface IModalView<T, TResult> {
		void Show(T value, Action<TResult> callback);
	}
}
