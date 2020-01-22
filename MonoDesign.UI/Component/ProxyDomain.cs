using System;
using System.Reflection;

namespace MonoDesign.UI.Component
{
	public class ProxyDomain: MarshalByRefObject
	{
		public Assembly GetAssembly(string assemblyPath) {
			try {
				return Assembly.LoadFrom(assemblyPath);
			} catch (Exception ex) {
				throw new InvalidOperationException(ex.Message);
			}
		}
    }
}
