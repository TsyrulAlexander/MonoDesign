using System;

namespace MonoDesign.Core {
	public static class GameServices {
		private static ServiceProvider _container;
		public static ServiceProvider Instance => _container ?? (_container = new ServiceProvider());
		public static T GetService<T>() {
			return (T) Instance.GetService(typeof(T));
		}
		public static object GetService(Type type) {
			return Instance.GetService(type);
		}
		public static void AddSingleton<TService>(TService instance = null) where TService : class {
			Instance.AddSingleton(instance);
		}
		public static void AddSingleton<TService, TImplementation>(Func<IServiceProvider, TImplementation> instance = null) where TService : class
			where TImplementation : class, TService {
			Instance.AddSingleton<TService, TImplementation>(instance);
		}
		public static void AddScoped<TService, TImplementation>(Func<IServiceProvider, TImplementation> instance = null) where TService : class
			where TImplementation : class, TService {
			Instance.AddScoped<TService, TImplementation>(instance);
		}
		public static void AddTransient<TService, TImplementation>(Func<IServiceProvider, TImplementation> instance = null) where TService : class
			where TImplementation : class, TService {
			Instance.AddTransient<TService, TImplementation>(instance);
		}
	}
}