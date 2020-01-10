using System;
using System.IO;
using MonoDesign.Core.Entity.Project;
using MonoDesign.Core.Entity.Scene;
using MonoDesign.Core.Utilities;

namespace MonoDesign.Engine
{
	public class DesignEngine {
		public string ProjectPath { get; }
		public ProjectInfo ProjectInfo { get; private set; }
		public string ProjectInfoPath => GetAbsolutePath(EngineSetting.ProjectInfoPath);
		public string SceneFormatPath => GetAbsolutePath(EngineSetting.SceneFormatPath);
		public DesignEngine(string projectPath) {
			ProjectPath = projectPath;
		}
		public virtual void LoadProject() {
			ProjectInfo = ProjectInfoPath
				.ReadWithFile()
				.DeserializeData<ProjectInfo>();
		}
		public virtual void SaveProject() {
			ProjectInfo.SerializeData()
			.SaveToFile(ProjectInfoPath);
		}
		public virtual Scene SaveScene(Scene scene) {
			var path = GetScenePath(SceneLookup.Create(scene));
			return path.ReadWithFile().DeserializeData<Scene>();
		}
		public virtual Scene LoadScene(SceneLookup lookup) {
			var path = GetScenePath(lookup);
			return path.ReadWithFile().DeserializeData<Scene>();
		}
		protected virtual string GetScenePath(SceneLookup lookup) {
			return string.Format(SceneFormatPath, lookup.Id);
		}
		protected virtual string GetAbsolutePath(string path) {
			return Path.Combine(ProjectPath, path);
		}
	}
}
