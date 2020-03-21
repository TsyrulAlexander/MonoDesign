using System;
using Microsoft.Extensions.DependencyInjection;

namespace MonoDesign.Core {
	public class ServiceProvider : IServiceProvider {
		private IServiceCollection Services { get; set; } = new ServiceCollection();
		private Microsoft.Extensions.DependencyInjection.ServiceProvider _provider;
		public void AddSingleton<TService>(TService instance = null) where TService : class {
			if (instance == null) {
				Services.AddSingleton<TService>();
			} else {
				Services.AddSingleton(provider => instance);
			}
		}
		public void AddSingleton<TService, TImplementation>(Func<IServiceProvider, TImplementation> instance = null) where TService : class
			where TImplementation : class, TService {
			if (instance == null) {
				Services.AddSingleton<TService, TImplementation>();
			} else {
				Services.AddSingleton<TService, TImplementation>(instance);
			}
		}
		public void AddScoped<TService, TImplementation>(Func<IServiceProvider, TImplementation> instance = null) where TService : class
			where TImplementation : class, TService {
			if (instance == null) {
				Services.AddScoped<TService, TImplementation>();
			} else {
				Services.AddScoped<TService, TImplementation>(instance);
			}
		}
		public void AddTransient<TService, TImplementation>(Func<IServiceProvider, TImplementation> instance = null) where TService : class
			where TImplementation : class, TService {
			if (instance == null) {
				Services.AddTransient<TService, TImplementation>();
			} else {
				Services.AddTransient<TService, TImplementation>(instance);
			}
		}

		public T GetService<T>() where T : class {
			return _provider.GetService<T>();
		}
		public object GetService(Type serviceType) {
			return _provider.GetService(serviceType);
		}
		public virtual void Build() {
			_provider?.Dispose();
			_provider = Services.BuildServiceProvider();
		}
		
	}
}