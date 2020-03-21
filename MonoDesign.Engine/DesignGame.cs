using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Component.Extension;
using MonoDesign.Core;
using MonoDesign.Engine.Extension;

namespace MonoDesign.Engine
{
	public class DesignGame: Game {
		public DesignEngine DesignEngine { get; set; }
		protected SpriteBatch SpriteBatch { get; set; }
		protected override void Initialize() {
			base.Initialize();
			SpriteBatch = GameServices.GetService<SpriteBatch>();
			LoadProject();
		}

		protected virtual void LoadProject() {
			var directory = Directory.GetCurrentDirectory();
			DesignEngine.LoadProject(directory);
		}

		protected override void Update(GameTime gameTime) {
			base.Update(gameTime);
			if (DesignEngine.CurrentScene == null) {
				return;
			}
			for (var index = 0; index < DesignEngine.CurrentScene.GameObjects.Count; index++) {
				DesignEngine.CurrentScene.GameObjects[index].Update(gameTime);
			}
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.CornflowerBlue);
			base.Draw(gameTime);
			if (DesignEngine.CurrentScene == null) {
				return;
			}
			SpriteBatch.Begin(DesignEngine.CurrentScene.SortMode,
				DesignEngine.CurrentScene.BlendState,
				DesignEngine.CurrentScene.SamplerState,
				DesignEngine.CurrentScene.DepthStencilState,
				DesignEngine.CurrentScene.RasterizerState,
				DesignEngine.CurrentScene.Effect,
				DesignEngine.CurrentScene.TransformMatrix);
			for (var index = 0; index < DesignEngine.CurrentScene.GameObjects.Count; index++) {
				DesignEngine.CurrentScene.GameObjects[index].Draw(gameTime);
			}
			SpriteBatch.End();
		}
		public virtual void ConfigureServices() {
			GameServices.Instance.AddSingleton<IGraphicsDeviceService, GraphicsDeviceManager>(provider => new GraphicsDeviceManager(this));
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
