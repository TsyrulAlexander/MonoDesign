using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MonoDesign.Core;
using MonoDesign.Engine;
using NLog.Extensions.Logging;

namespace MonoDesign.Game {
	public class MyGame : DesignGame {
		protected override void LoadContent() {
			base.LoadContent();
			var firstScene = DesignEngine.ProjectInfo.Scenes.FirstOrDefault();
			if (firstScene == null) {
				return;
			}
			DesignEngine.LoadScene(firstScene);
		}
		public override void ConfigureServices() {
			GameServices.Instance.Services.AddLogging(builder =>
				builder.AddNLog("NLog.config")
			);
			base.ConfigureServices();
		}
	}
}