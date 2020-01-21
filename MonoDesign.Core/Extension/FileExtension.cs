using System;
using System.Collections.Generic;
using System.Text;
using MonoDesign.Core.File;

namespace MonoDesign.Core.Extension {
	public static class FileExtension {
		public static void UseFile(this ServiceProvider provider) {
			provider.AddSingleton<IFileService, FileService>();
		}
	}
}
