using MonoDesign.Core.File;
using MonoDesign.Core.Serialization;
using MonoDesign.Core.Utilities;
using MonoDesign.Engine.Project;

namespace MonoDesign.Engine.Manager {
	public class ProjectManager : IProjectManager {
		private readonly ISerializer _serializer;
		private readonly IFileService _fileService;
		public ProjectManager(ISerializer serializer, IFileService fileService) {
			_serializer = serializer;
			_fileService = fileService;
		}
		public virtual void Save(ProjectInfo item) {
			if (!_fileService.Exists(item.Path)) {
				CreateProjectHierarchy(item);
			}
			var bytes = _serializer.SerializeData(item);
			_fileService.SaveToFile(bytes, item.Path);
		}
		public virtual void Remove(ProjectInfo item) {
			var directory = _fileService.GetDirectory(item.Path);
			_fileService.RemoveDirectory(directory);
		}
		public virtual ProjectInfo Load(string path) {
			var bytes = _fileService.ReadWithFile(path);
			var projectInfo = _serializer.DeserializeData<ProjectInfo>(bytes);
			projectInfo.Path = path;
			return projectInfo;
		}
		protected virtual void CreateProjectHierarchy(ProjectInfo info) {
			var directory = _fileService.GetDirectory(info.Path);
			_fileService.CreateDirectory(directory);
		}
	}
}
