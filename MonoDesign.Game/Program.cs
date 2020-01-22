using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Component.Extension;
using MonoDesign.Core;
using MonoDesign.Engine;
using MonoDesign.Engine.Extension;

namespace MonoDesign.Game {
	public static class Program {
		[STAThread]
		static void Main() {
			using (var game = new MyGame()) {
				ConfigureServices(game);
				var graphicsDeviceService = GameServices.GetService<IGraphicsDeviceService>();
				game.Services.AddService(graphicsDeviceService.GetType(), graphicsDeviceService);
				game.DesignEngine = GameServices.GetService<DesignEngine>();
				game.Run();
			}
		}
		private static void ConfigureServices(Microsoft.Xna.Framework.Game game) {
			GameServices.Instance.AddSingleton<IGraphicsDeviceService, GraphicsDeviceManager>(provider => new GraphicsDeviceManager(game));
			GameServices.Instance.AddSingleton<SpriteBatch, SpriteBatch>(provider => {
				var service = (IGraphicsDeviceService)provider.GetService(typeof(IGraphicsDeviceService));
				return new SpriteBatch(service.GraphicsDevice);
			});
			GameServices.Instance.UseComponent();
			GameServices.Instance.UseDesignEngine();
			GameServices.Instance.Build();
		}
	}
}
