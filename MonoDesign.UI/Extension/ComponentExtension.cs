using MonoDesign.Core;
using MonoDesign.Core.Entity.Component;
using MonoDesign.UI.Component.Component;
using MonoDesign.UI.View.Component;

namespace MonoDesign.UI.Extension {
	public static class ComponentExtension {
		public static void UseComponent(this ServiceProvider provider) {
			provider.AddTransient<IComponentView<PositionComponent>, PositionComponentView>();
			provider.AddTransient<IComponentView<TextureComponent>, TextureComponentView>();
		}
	}
}