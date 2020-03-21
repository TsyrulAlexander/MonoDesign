using System;
using System.Reflection;
using MonoDesign.Engine;
using MonoDesign.Engine.Project;

namespace MonoDesign.UI.Utilities {
	public class AssemblyUtilities {
		public static void GetProjectAssembly(DesignEngine designEngine, Action<Assembly> action) {
			var dllPath = designEngine.GetProjectDllPath();
			var domainName = Guid.NewGuid().ToString();
			var domain = AppDomain.CreateDomain(domainName);
			try {
				var proxyType = typeof(ProxyDomain);
				var proxy = (ProxyDomain)domain.CreateInstanceAndUnwrap(proxyType.Assembly.FullName,
					proxyType.FullName);
				var assembly = proxy.GetAssembly(dllPath);
				var scripts = proxy.LoadScripts(assembly);
				
			} catch (Exception ex) {

			} finally {
				AppDomain.Unload(domain);
			}
		}
	}
}