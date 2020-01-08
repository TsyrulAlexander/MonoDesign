using System;
using System.Drawing;

namespace MonoDesign.Core {
	public class SizeChangedEventArgs : EventArgs {
		public Size NewSize { get; set; }
		public SizeChangedEventArgs(Size newSize) {
			NewSize = newSize;
		}
	}
}
