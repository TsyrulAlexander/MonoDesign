using System.Configuration;

namespace MonoDesign.Engine
{
	public class EngineSetting {
		public static string ProjectInfoPath => GetStringValue(nameof(ProjectInfoPath));
		public static string SceneFormatPath => GetStringValue(nameof(SceneFormatPath));
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
