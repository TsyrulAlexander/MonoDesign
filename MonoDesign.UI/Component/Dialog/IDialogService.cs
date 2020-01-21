using System;

namespace MonoDesign.UI.Component.Dialog
{
	public interface IDialogService {
		void ShowModal<T, TResult>(T value, Action<TResult> callback);
		string SelectFolder(string path = null);
		string SaveFile(string directory = "", string filter = "");
		string SelectFile(string filter = "");

	}
}
