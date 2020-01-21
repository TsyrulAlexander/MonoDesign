using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Core;
using MonoDesign.Core.File;
using MonoDesign.Engine.Project;

namespace MonoDesign.Engine.Manager {
	public class AssetManager : IAssetManager {
		private const string TextureFolder = "Texture";
		private readonly IFileService _fileService;
		private readonly ContentManager _contentManager;
		public AssetManager(IFileService fileService) {
			_fileService = fileService;
			_contentManager = new ContentManager(GameServices.Instance);
		}
		public Texture2D LoadTexture(ProjectInfo projectInfo, string assetName) {
			var texturePath = _fileService.CombinePath(GetTextureFolder(projectInfo), assetName);
			return _contentManager.Load<Texture2D>(texturePath);
		}
		public string SaveTextureToAsset(ProjectInfo projectInfo, string path) {
			var textureFolder = GetTextureFolder(projectInfo);
			var fileName = _fileService.GetFileName(path);
			var newTexturePath = _fileService.CombinePath(textureFolder, fileName);
			_fileService.CopyFile(path, newTexturePath);
			var assetName = fileName.Replace(_fileService.GetExtension(fileName), "");
			return assetName;
		}
		public string GetTextureFolder(ProjectInfo projectInfo) {
			var contentFolder = GetContentFolder(projectInfo);
			return _fileService.CombinePath(contentFolder, TextureFolder);
		}
		public string GetContentFolder(ProjectInfo projectInfo) {
			var directory = _fileService.GetDirectory(projectInfo.Path);
			var assetsFolder = EngineSetting.AssetsFolder;
			return _fileService.CombinePath(directory, assetsFolder);
		}
	}
}
