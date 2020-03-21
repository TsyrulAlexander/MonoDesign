using MonoDesign.Core.Entity.Scene;
using MonoDesign.Core.File;
using MonoDesign.Core.Serialization;
using MonoDesign.Engine.Project;

namespace MonoDesign.Engine.Manager {
	public class SceneManager: ISceneManager {
		private readonly ISerializer _serializer;
		private readonly IFileService _fileService;
		private const string SceneFileName = "scene.info";
		public SceneManager(ISerializer serializer, IFileService fileService) {
			_serializer = serializer;
			_fileService = fileService;
		}
		public void Save(ProjectInfo projectInfo, Scene item) {
			SaveScene(projectInfo, item);

		}
		protected void SaveScene(ProjectInfo projectInfo, Scene item) {
			var scenePath = GetSceneFilePath(projectInfo, SceneLookup.Create(item));
			CreateIfNotExists(scenePath);
			var bytes = _serializer.SerializeData(item);
			_fileService.SaveToFile(bytes, scenePath);
		}
		public void Remove(ProjectInfo projectInfo, SceneLookup item) {
			var sceneDirectory = GetSceneFolder(projectInfo, item);
			_fileService.RemoveDirectory(sceneDirectory);
		}
		public string GetSceneFolder(ProjectInfo projectInfo) {
			var sceneFolder = EngineSetting.ScenesFolder;
			return _fileService.CombinePath(projectInfo.RootDirectory, sceneFolder);
		}
		public Scene Load(ProjectInfo projectInfo, SceneLookup scene) {
			var path = GetSceneFilePath(projectInfo, scene);
			CreateIfNotExists(path);
			var bytes = _fileService.ReadWithFile(path);
			return _serializer.DeserializeData<Scene>(bytes);
		}
		protected virtual void CreateIfNotExists(string path) {
			var directory = _fileService.GetDirectory(path);
			if (_fileService.Exists(path)) {
				return;
			}
			_fileService.CreateDirectory(directory);
		}
		protected virtual string GetSceneFolder(ProjectInfo projectInfo, SceneLookup lookup) {
			var scenesFolder = GetSceneFolder(projectInfo);
			return _fileService.CombinePath(scenesFolder, lookup.Id.ToString());
		}
		protected virtual string GetSceneFilePath(ProjectInfo projectInfo, SceneLookup lookup) {
			var sceneFolder = GetSceneFolder(projectInfo, lookup);
			return _fileService.CombinePath(sceneFolder, SceneFileName);
		}
	}
}
