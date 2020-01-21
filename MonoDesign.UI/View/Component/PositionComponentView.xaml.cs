using System.Windows.Controls;
using MonoDesign.Core.Entity.Component;
using MonoDesign.UI.Component.Component;

namespace MonoDesign.UI.View.Component
{
	/// <summary>
	/// Interaction logic for PositionComponent.xaml
	/// </summary>
	public partial class PositionComponentView : UserControl, IComponentView<PositionComponent> {
		public PositionComponentView() {
			InitializeComponent();
		}
	}
}
