using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Core;
using MonoDesign.Engine;

namespace MonoDesign.Game.DesktopGL
{
	public static class Program
	{
		[STAThread]
		static void Main() {
			using (var game = new MyGame()) {
				game.ConfigureServices();
				var graphicsDeviceService = GameServices.GetService<IGraphicsDeviceService>();
				game.Services.AddService(graphicsDeviceService.GetType(), graphicsDeviceService);
				game.DesignEngine = GameServices.GetService<DesignEngine>();
				game.Run();
			}
		}
	}
}
