using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Core;
using MonoDesign.Engine;

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
	}
}