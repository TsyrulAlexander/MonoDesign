namespace MonoDesign.Core {
	public static class GameServices {
		private static ServiceProvider _container;
		public static ServiceProvider Instance => _container ?? (_container = new ServiceProvider());
		public static T GetService<T>() {
			return (T) Instance.GetService(typeof(T));
		}

		public static void AddSingleton<TService, TImplementation>(TImplementation instance = null) where TService : class
			where TImplementation : class, TService {
			Instance.AddSingleton<TService, TImplementation>(instance);
			Instance.Build();
		}
		public static void AddScoped<TService, TImplementation>(TImplementation instance = null) where TService : class
			where TImplementation : class, TService {
			Instance.AddScoped<TService, TImplementation>(instance);
			Instance.Build();
		}
		public static void AddTransient<TService, TImplementation>(TImplementation instance = null) where TService : class
			where TImplementation : class, TService {
			Instance.AddTransient<TService, TImplementation>(instance);
			Instance.Build();
		}
	}
}