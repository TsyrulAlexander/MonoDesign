using System.Windows.Controls;
using MonoDesign.Component;
using MonoDesign.UI.Component.Component;

namespace MonoDesign.UI.View.Component
{
	/// <summary>
	/// Interaction logic for TextureComponentView.xaml
	/// </summary>
	public partial class TextureComponentView : UserControl, IComponentView<TextureComponent>
	{
		public TextureComponentView() {
			InitializeComponent();
		}
	}
}
