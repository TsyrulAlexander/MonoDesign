using MonoDesign.Component.Script;
using MonoDesign.Core;

namespace MonoDesign.Component.Extension {
	public static class ComponentExtension {
		public static void UseComponent(this ServiceProvider provider) {
			provider.AddTransient<TextureComponent, TextureComponent>();
			provider.AddTransient<PositionComponent, PositionComponent>();
			provider.AddTransient<ScriptComponent, ScriptComponent>();
		}
	}
}