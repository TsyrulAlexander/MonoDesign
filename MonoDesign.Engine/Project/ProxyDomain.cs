using System;
using System.Reflection;

namespace MonoDesign.Engine.Project
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
