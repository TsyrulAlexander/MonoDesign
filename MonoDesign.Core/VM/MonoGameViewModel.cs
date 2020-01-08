using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoDesign.Core.VM {

	public class MonoGameViewModel : ViewModel, IMonoGameViewModel {
		public MonoGameViewModel(IGraphicsDeviceService graphicsDeviceService = null) {
			GraphicsDeviceService = graphicsDeviceService;
		}

		public void Dispose() {
			Content?.Dispose();
		}

		public IGraphicsDeviceService GraphicsDeviceService { get; set; }
		protected GraphicsDevice GraphicsDevice => GraphicsDeviceService?.GraphicsDevice;
		protected ContentManager Content { get; set; }

		public virtual void Initialize() {
			GraphicsDeviceService = GraphicsDeviceService ?? GameServices.GetService<IGraphicsDeviceService>();
			Content = new ContentManager(GameServices.Instance) {RootDirectory = "Content"};
		}
		public virtual void LoadContent() { }
		public virtual void UnloadContent() { }
		public virtual void Update(GameTime gameTime) { }
		public virtual void Draw(GameTime gameTime) { }
		public virtual void OnActivated(object sender, EventArgs args) { }
		public virtual void OnDeactivated(object sender, EventArgs args) { }
		public virtual void OnExiting(object sender, EventArgs args) { }
		public virtual void SizeChanged(object sender, SizeChangedEventArgs args) { }
	}
}