using System.Windows;
using System.Windows.Controls;
using MonoDesign.UI.Component.Property;

namespace MonoDesign.UI.View.Property {
	public partial class StringPropertyControl : UserControl {
		public static readonly DependencyProperty StringProperty =
			DependencyProperty.Register("Property", typeof(StringProperty), typeof(StringPropertyControl));
		public StringProperty Property {
			get => GetValue(StringProperty) as StringProperty;
			set => SetValue(StringProperty, value);
		}

		public StringPropertyControl() {
			InitializeComponent(); 
		}
	}
}
