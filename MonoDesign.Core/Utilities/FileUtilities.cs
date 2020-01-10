using System.IO;

namespace MonoDesign.Core.Utilities {
	public static class FileUtilities {
		public static void SaveToFile(this byte[] bytes, string path) {
			File.WriteAllBytes(path, bytes);
		}
		public static byte[] ReadWithFile(this string path) {
			return File.ReadAllBytes(path);
		}
	}
}
