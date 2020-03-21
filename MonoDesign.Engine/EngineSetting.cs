using System.Configuration;

namespace MonoDesign.Engine
{
	public class EngineSetting {
		public static string ProjectInfoFileName => GetStringValue(nameof(ProjectInfoFileName));
		public static string ScenesFolder => GetStringValue(nameof(ScenesFolder));
		public static string AssetsFolder => GetStringValue(nameof(AssetsFolder));
		public static string SolutionDebugBuildFolder => GetStringValue(nameof(SolutionDebugBuildFolder));

		private static string GetStringValue(string key) {
			var exeConfigPath = typeof(EngineSetting).Assembly.Location;
			var element = ConfigurationManager.OpenExeConfiguration(exeConfigPath).AppSettings?.Settings[key];
			if (element != null && !string.IsNullOrWhiteSpace(element.Value)) {
				return element.Value;
			}
			return string.Empty;
		}
	}
}
