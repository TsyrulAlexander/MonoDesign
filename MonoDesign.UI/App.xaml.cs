using System.Windows;
using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Component.Extension;
using MonoDesign.Core;
using MonoDesign.Engine.Extension;
using MonoDesign.UI.Extension;
using MonoDesign.UI.MonoGame;

namespace MonoDesign.UI {
	public partial class App : Application {
		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);
			GameServices.Instance.UseViewModel();
			GameServices.Instance.UseDialog();
			GameServices.Instance.UseModal();
			GameServices.Instance.UseComponentView();
			GameServices.Instance.AddSingleton<IGraphicsDeviceService, MonoGameGraphicsDeviceService>();
			GameServices.Instance.AddSingleton<SpriteBatch, SpriteBatch>(provider => {
				var service = (IGraphicsDeviceService) provider.GetService(typeof(IGraphicsDeviceService));
				return new SpriteBatch(service.GraphicsDevice);
			});
			GameServices.Instance.UseComponent();
			GameServices.Instance.UseDesignEngine();
			GameServices.Instance.Build();
		}
	}
}