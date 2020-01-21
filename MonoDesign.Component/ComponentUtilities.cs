using System.Collections.Generic;
using System.Linq;
using MonoDesign.Component.Attribute;
using MonoDesign.Core.Entity.Reflection;
using MonoDesign.Core.Utilities;

namespace MonoDesign.Component {
	public static class ComponentUtilities {
		public static IEnumerable<AttributeInfo<ComponentAttribute>> GetComponents() {
			var assemblies = ReflectionUtilities.GetAssemblies<ComponentAssemblyAttribute>();
			return ReflectionUtilities.GetTypesInfoWithAttribute<ComponentAttribute>(assemblies.ToArray());
		}
	}
}