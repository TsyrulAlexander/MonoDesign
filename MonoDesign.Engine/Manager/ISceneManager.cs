using MonoDesign.Core.Entity.Scene;
using MonoDesign.Engine.Project;

namespace MonoDesign.Engine.Manager
{
	public interface ISceneManager {
		void Save(ProjectInfo projectInfo, Scene scene);
		Scene Load(ProjectInfo projectInfo, SceneLookup scene);
		void Remove(ProjectInfo projectInfo, SceneLookup scene);
		string GetSceneFolder(ProjectInfo projectInfo);
	}
}
