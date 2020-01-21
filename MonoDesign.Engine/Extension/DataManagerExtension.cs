using MonoDesign.Core;
using MonoDesign.Core.Entity.Scene;
using MonoDesign.Engine.Manager;

namespace MonoDesign.Engine.Extension {
	public static class DataManagerExtension {
		public static void UseDataManager(this ServiceProvider provider) {
			provider.AddSingleton<DesignEngine>();
			provider.AddSingleton<ISceneManager, SceneManager>();
			provider.AddSingleton<IProjectManager, ProjectManager>();
			provider.AddSingleton<IAssetManager, AssetManager>();
		}
	}
}
