using MonoDesign.Component;
using MonoDesign.Component.Script;
using MonoDesign.Core;
using MonoDesign.UI.Component.Component;
using MonoDesign.UI.View.Component;

namespace MonoDesign.UI.Extension {
	public static class ComponentExtension {
		public static void UseComponentView(this ServiceProvider provider) {
			provider.AddTransient<IComponentView<PositionComponent>, PositionComponentView>();
			provider.AddTransient<IComponentView<TextureComponent>, TextureComponentView>();
			provider.AddTransient<IComponentView<ScriptComponent>, ScriptComponentView>();
		}
	}
}