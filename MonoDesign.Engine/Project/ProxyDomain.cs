using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MonoDesign.Component.Script;
using MonoDesign.Core.Entity.Reflection;
using MonoDesign.Core.Utilities;

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
		public IEnumerable<AttributeInfo<ScriptAttribute>> LoadScripts(Assembly assembly) {
			var types = assembly.GetTypes();
			var attributeInfos = types.Where(type => type.GetCustomAttribute<ScriptAttribute>() != null).Select(type =>
				new AttributeInfo<ScriptAttribute>(type.GetCustomAttribute<ScriptAttribute>(), type));
			return attributeInfos.ToArray();
		}
	}
}
