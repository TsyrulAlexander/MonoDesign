using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Core.VM;

namespace MonoDesign.UI.ViewModel {
	public class ViewPortViewModel : MonoGameViewModel {
		private SpriteBatch _spriteBatch;

		public override void LoadContent() {
			_spriteBatch = new SpriteBatch(GraphicsDevice);
		}

		public override void Update(GameTime gameTime) { }

		public override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.CornflowerBlue);
			_spriteBatch.Begin();
			_spriteBatch.End();
		}
	}
}