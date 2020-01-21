using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using MonoDesign.Core;
using MonoDesign.Core.VM;
using Color = Microsoft.Xna.Framework.Color;

namespace MonoDesign.Game {
	public class MyGame : Microsoft.Xna.Framework.Game {
		readonly GraphicsDeviceManager _graphics;
		private IMonoGameViewModel ViewModel { get; set; }
		public MyGame() {
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
			ViewModel = new MonoGameViewModel(_graphics);
			this.Window.AllowUserResizing = true;
			Window.ClientSizeChanged += WindowOnClientSizeChanged;
		}
		private void WindowOnClientSizeChanged(object sender, EventArgs e) {
			ViewModel.SizeChanged(sender, new SizeChangedEventArgs(new Size(GraphicsDevice.Viewport.Width,
				GraphicsDevice.Viewport.Height)));
		}
		protected override void Initialize() {
			ViewModel.Initialize();
			base.Initialize();
		}

		protected override void LoadContent() {
			ViewModel.LoadContent();
		}

		protected override void Update(GameTime gameTime) {
			ViewModel.Update(gameTime);
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.CornflowerBlue);
			ViewModel.Draw(gameTime);
			base.Draw(gameTime);
		}
		protected override void UnloadContent() {
			ViewModel.UnloadContent();
			base.UnloadContent();
		}
		protected override void OnActivated(object sender, EventArgs args) {
			ViewModel.OnActivated(sender, args);
			base.OnActivated(sender, args);
		}
		protected override void OnDeactivated(object sender, EventArgs args) {
			ViewModel.OnDeactivated(sender, args);
			base.OnDeactivated(sender, args);
		}
		protected override void OnExiting(object sender, EventArgs args) {
			ViewModel.OnExiting(sender, args);
			base.OnExiting(sender, args);
		}
		protected override void Dispose(bool disposing) {
			ViewModel.Dispose();
			base.Dispose(disposing);
		}
	}
}