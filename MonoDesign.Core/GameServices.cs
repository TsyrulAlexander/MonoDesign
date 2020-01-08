namespace MonoDesign.Core {
	public static class GameServices {
		private static ServiceProvider _container;
		public static ServiceProvider Instance => _container ?? (_container = new ServiceProvider());
		public static T GetService<T>() {
			return (T) Instance.GetService(typeof(T));
		}

		public static void AddService<T>(T service) {
			Instance.AddService(typeof(T), service);
		}

		public static void RemoveService<T>() {
			Instance.RemoveService(typeof(T));
		}
	}
}