using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MonoDesign.UI.Utilities
{
	public static class CastUtilities
	{
		public static Core.SizeChangedEventArgs Cast(this SizeChangedEventArgs sizeChangedEventArgs) {
			return new Core.SizeChangedEventArgs(sizeChangedEventArgs.NewSize.Cast());
		}
		public static System.Drawing.Size Cast(this Size size) {
			return new System.Drawing.Size((int)size.Width, (int)size.Height);
		}
	}
}
