using System;
using Microsoft.Extensions.DependencyInjection;

namespace MonoDesign.Core {
	public class ServiceProvider : IServiceProvider {
		private readonly ServiceCollection _services;
		private Microsoft.Extensions.DependencyInjection.ServiceProvider _provider;
		public ServiceProvider() {
			_services = new ServiceCollection();
		}

		public void AddSingleton<TService, TImplementation>(TImplementation instance = null) where TService : class
			where TImplementation : class, TService {
			if (instance == null) {
				_services.AddSingleton<TService, TImplementation>();
			} else {
				_services.AddSingleton<TService, TImplementation>(provider => instance);
			}
		}
		public void AddScoped<TService, TImplementation>(TImplementation instance = null) where TService : class
			where TImplementation : class, TService {
			if (instance == null) {
				_services.AddScoped<TService, TImplementation>();
			} else {
				_services.AddScoped<TService, TImplementation>(provider => instance);
			}
		}
		public void AddTransient<TService, TImplementation>(TImplementation instance = null) where TService : class
			where TImplementation : class, TService {
			if (instance == null) {
				_services.AddTransient<TService, TImplementation>();
			} else {
				_services.AddTransient<TService, TImplementation>(provider => instance);
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
			_provider = _services.BuildServiceProvider();
		}
		
	}
}