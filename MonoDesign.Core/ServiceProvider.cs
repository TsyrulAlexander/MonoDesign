using System;
using Microsoft.Extensions.DependencyInjection;

namespace MonoDesign.Core {
	public class ServiceProvider : IServiceProvider {
		private readonly ServiceCollection _services;
		private Microsoft.Extensions.DependencyInjection.ServiceProvider _provider;
		public ServiceProvider() {
			_services = new ServiceCollection();
		}
		public void AddSingleton<TService>(TService instance = null) where TService : class {
			if (instance == null) {
				_services.AddSingleton<TService>();
			} else {
				_services.AddSingleton(provider => instance);
			}
		}
		public void AddSingleton<TService, TImplementation>(Func<IServiceProvider, TImplementation> instance = null) where TService : class
			where TImplementation : class, TService {
			if (instance == null) {
				_services.AddSingleton<TService, TImplementation>();
			} else {
				_services.AddSingleton<TService, TImplementation>(instance);
			}
		}
		public void AddScoped<TService, TImplementation>(Func<IServiceProvider, TImplementation> instance = null) where TService : class
			where TImplementation : class, TService {
			if (instance == null) {
				_services.AddScoped<TService, TImplementation>();
			} else {
				_services.AddScoped<TService, TImplementation>(instance);
			}
		}
		public void AddTransient<TService, TImplementation>(Func<IServiceProvider, TImplementation> instance = null) where TService : class
			where TImplementation : class, TService {
			if (instance == null) {
				_services.AddTransient<TService, TImplementation>();
			} else {
				_services.AddTransient<TService, TImplementation>(instance);
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