using System.Windows;
using System.Windows.Controls;
using MonoDesign.Core;
using MonoDesign.Core.Entity.Component;
using MonoDesign.UI.Component.Component;

namespace MonoDesign.UI.View.Component {
	public partial class ComponentView : UserControl {
		public static readonly DependencyProperty ComponentProperty =
			DependencyProperty.Register("Component", typeof(IGameObjectComponent), typeof(ComponentView), new UIPropertyMetadata(PropertyChangedCallback));
		private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			ComponentView componentView = d as ComponentView;
			SetComponent(componentView, (IGameObjectComponent) e.NewValue);
		}
		public IGameObjectComponent Component {
			get => GetValue(ComponentProperty) as IGameObjectComponent;
			set => SetValue(ComponentProperty, value);
		}
		public ComponentView() {
			InitializeComponent();
		}
		private static void SetComponent(ComponentView componentView, IGameObjectComponent component) {
			var view = GetView(component);
			var viewModel = GetViewModel(view);
			viewModel.SetValue(component);
			componentView.Content = view;
		}
		private static ContentControl GetView(IGameObjectComponent component) {
			var viewGenericType = typeof(IComponentView<>);
			var viewGeneric = viewGenericType.MakeGenericType(component.GetType());
			var view = GameServices.GetService(viewGeneric);
			return (ContentControl)view;
		}
		private static IComponentViewModel GetViewModel(ContentControl contentControl) {
			return (IComponentViewModel)contentControl.DataContext;
		}
	}
}