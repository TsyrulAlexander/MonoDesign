using MonoDesign.Core;
using MonoDesign.Core.Extension;

namespace MonoDesign.Engine.Extension {
	public static class DesignEngineExtension {
		public static void UseDesignEngine(this ServiceProvider provider) {
			provider.UseDataManager();
			provider.UseGameSerializer();
			provider.UseFile();
			provider.UseProcess();
			provider.UseMessenger();
		}
	}
}