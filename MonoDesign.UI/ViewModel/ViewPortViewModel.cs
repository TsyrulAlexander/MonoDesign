using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Core;
using MonoDesign.Core.VM;
using MonoDesign.Engine;

namespace MonoDesign.UI.ViewModel {
	public class ViewPortViewModel : MonoGameViewModel {
		private readonly DesignEngine _designEngine;
		private SpriteBatch _spriteBatch;
		public ViewPortViewModel(DesignEngine designEngine) {
			_designEngine = designEngine;
		}
		public override void Initialize() {
			base.Initialize();
			_spriteBatch = GameServices.GetService<SpriteBatch>();
		}
		public override void Update(GameTime gameTime) {
			if (_designEngine.CurrentScene == null) {
				return;
			}
			for (var index = 0; index < _designEngine.CurrentScene.GameObjects.Count; index++) {
				_designEngine.CurrentScene.GameObjects[index].Update(gameTime);
			}
		}

		public override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.Coral);
			if (_designEngine.CurrentScene == null) {
				return;
			}
			_spriteBatch.Begin(_designEngine.CurrentScene.SortMode,
				_designEngine.CurrentScene.BlendState,
				_designEngine.CurrentScene.SamplerState,
				_designEngine.CurrentScene.DepthStencilState,
				_designEngine.CurrentScene.RasterizerState,
				_designEngine.CurrentScene.Effect,
				_designEngine.CurrentScene.TransformMatrix);
			for (var index = 0; index < _designEngine.CurrentScene.GameObjects.Count; index++) {
				_designEngine.CurrentScene.GameObjects[index].Draw(gameTime);
			}
			_spriteBatch.End();
		}
	}
}