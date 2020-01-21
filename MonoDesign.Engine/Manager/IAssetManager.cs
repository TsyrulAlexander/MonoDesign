using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Engine.Project;

namespace MonoDesign.Engine.Manager
{
	public interface IAssetManager {
		Texture2D LoadTexture(ProjectInfo projectInfo, string assetName);
		string SaveTextureToAsset(ProjectInfo projectInfo, string path);
		string GetContentFolder(ProjectInfo projectInfo);
	}
}
