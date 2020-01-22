namespace MonoDesign.Core.File
{
	public interface IFileService {
		void SaveToFile(byte[] bytes, string path);
		byte[] ReadWithFile(string path);
		bool Exists(string path);
		string GetDirectory(string path);
		void CreateDirectory(string directory);
		void RemoveDirectory(string directory);
		string CombinePath(params string[] paths);
		void CopyFile(string source, string path);
		string GetFileName(string path);
		string GetExtension(string path);
		bool GetIsDirectory(string path);
	}
}
