using System.Collections.ObjectModel;
using System.Reflection;
using MonoDesign.Component.Attribute;
using MonoDesign.Core.Entity.Reflection;
using MonoDesign.Core.Utilities;

namespace MonoDesign.Component.Script
{
	[Component("Script")]
	public class ScriptComponent: BaseComponent {
		public ObservableCollection<AttributeInfo<ScriptAttribute>> Scripts { get; set; } = new ObservableCollection<AttributeInfo<ScriptAttribute>>();
		public ScriptComponent() { }
		public void ReloadScripts(Assembly assembly) {
			Scripts.Clear();
			LoadScripts(assembly);
		}
		protected virtual void LoadScripts(Assembly assembly) {
			var scriptTypeInfos = ReflectionUtilities.GetTypesInfoWithAttribute<ScriptAttribute>(assembly);
			foreach (var scriptTypeInfo in scriptTypeInfos) {
				Scripts.Add(scriptTypeInfo);
			}
		}
	}
}
