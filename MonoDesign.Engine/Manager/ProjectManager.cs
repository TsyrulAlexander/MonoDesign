using MonoDesign.Core.File;
using MonoDesign.Core.Process;
using MonoDesign.Core.Serialization;
using MonoDesign.Engine.Project;

namespace MonoDesign.Engine.Manager {
	public class ProjectManager : IProjectManager {
		private readonly ISerializer _serializer;
		private readonly IFileService _fileService;
		private readonly IProcessService _processService;
		public const string SolutionFolder = "Solution";
		public string ProjectInfoFile => EngineSetting.ProjectInfoFileName;
		public ProjectManager(ISerializer serializer, IFileService fileService, IProcessService processService) {
			_serializer = serializer;
			_fileService = fileService;
			_processService = processService;
		}
		public virtual void Save(ProjectInfo item) {
			if (!_fileService.Exists(item.RootDirectory)) {
				CreateProjectHierarchy(item);
			}
			var bytes = _serializer.SerializeData(item);
			var projectInfoFilePath = GetProjectInfoFilePath(item);
			_fileService.SaveToFile(bytes, projectInfoFilePath);
		}
		public virtual void Remove(ProjectInfo item) {
			_fileService.RemoveDirectory(item.RootDirectory);
		}
		public virtual ProjectInfo Load(string path) {
			var bytes = _fileService.ReadWithFile(path);
			var projectInfo = _serializer.DeserializeData<ProjectInfo>(bytes);
			var rootDirectory = _fileService.GetDirectory(path);
			projectInfo.RootDirectory = rootDirectory;
			return projectInfo;
		}
		protected virtual void CreateProjectHierarchy(ProjectInfo info) {
			_fileService.CreateDirectory(info.RootDirectory);
			CreateProjectSolutions(info);
		}
		protected virtual string GetProjectInfoFilePath(ProjectInfo info) {
			return _fileService.CombinePath(info.RootDirectory, ProjectInfoFile);
		}
		public virtual string GetProjectSolutionPath(ProjectInfo info) {
			return _fileService.CombinePath(info.RootDirectory, SolutionFolder);
		}
		protected virtual void CreateProjectSolutions(ProjectInfo info) {
			var solutionFolder = GetProjectSolutionPath(info);
			_processService.StartProcess("cmd.exe", $"/C dotnet new monodesign -n {info.Name} -o {solutionFolder}");
		}
		public void BuildProject(ProjectInfo info) {
			var solutionFolder = GetProjectSolutionPath(info);
			_processService.StartProcess("cmd.exe", $"/C dotnet build {info.Name}.csproj -c Debug -r win10-x64", false, solutionFolder);
		}
		public void BuildPlatformProject(PlatformType type) {
			var solutionFolder = GetProjectSolutionPath(info);
			_processService.StartProcess("cmd.exe", $"/C dotnet build {info.Name}.csproj -c Debug -r win10-x64", false, solutionFolder);
		}
	}
}
