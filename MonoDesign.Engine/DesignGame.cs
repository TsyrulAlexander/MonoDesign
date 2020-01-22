using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Core;

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
	}
}
