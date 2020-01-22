using System.Reflection;
using MonoDesign.Component.Script;
using MonoDesign.Engine;
using MonoDesign.UI.Component.Component;
using MonoDesign.UI.Utilities;

namespace MonoDesign.UI.ViewModel.Component
{
	public class ScriptComponentViewModel: BaseComponentViewModel<ScriptComponent>
	{
		private readonly DesignEngine _designEngine;
		public ScriptComponentViewModel(DesignEngine designEngine) {
			_designEngine = designEngine;
		}
		public override void Initialize() {
			base.Initialize();
			AssemblyUtilities.GetProjectAssembly(_designEngine, LoadScriptsAction);
		}
		protected virtual void LoadScriptsAction(Assembly assembly) {
			Value.ReloadScripts(assembly);
		}
	}
}
