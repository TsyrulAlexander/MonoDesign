using System.Windows;
using MonoDesign.Core;
using MonoDesign.Engine.Extension;
using MonoDesign.UI.Extension;

namespace MonoDesign.UI
{
    public partial class App : Application
    {
		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);
			GameServices.Instance.UseViewModel();
			GameServices.Instance.UseDataManager();
			GameServices.Instance.Build();
		}
	}
}
