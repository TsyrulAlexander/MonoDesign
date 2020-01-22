using System;
using System.Collections.Generic;
using System.Text;
using MonoDesign.Core.Process;

namespace MonoDesign.Core.Extension
{
	public static class ProcessExtension
	{
		public static void UseProcess(this ServiceProvider provider) {
			provider.AddSingleton<IProcessService, ProcessService>();
		}
	}
}
