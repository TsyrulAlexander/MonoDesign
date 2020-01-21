using MonoDesign.Engine.Project;

namespace MonoDesign.Engine.Manager {
	public interface IProjectManager {
		void Save(ProjectInfo projectInfo);
		ProjectInfo Load(string path);
		void Remove(ProjectInfo projectInfo);
	}
}