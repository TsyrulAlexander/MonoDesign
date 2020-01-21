using MonoDesign.Core.Messages;

namespace MonoDesign.Core.Extension {
	public static class MessengerExtension {
		public static void UseMessenger(this ServiceProvider provider) {
			provider.AddSingleton<IMessenger, Messenger>();
		}
	}
}
