using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoDesign.Core;
using MonoDesign.UI.Component.Dialog;

namespace MonoDesign.UI.Extension
{
	public static class DialogExtension
	{
		public static void UseDialog(this ServiceProvider provider) {
			provider.AddSingleton<IDialogService, DialogService>();
		}
	}
}
