namespace MonoDesign.Core.Process {
	public class ProcessService : IProcessService {
		public void StartProcess(string name, string command, bool isHidden = false, string workingDirectory = "") {
			var process = new System.Diagnostics.Process();
			var startInfo = new System.Diagnostics.ProcessStartInfo();
			if (!string.IsNullOrWhiteSpace(workingDirectory)) {
				startInfo.WorkingDirectory = workingDirectory;
			}
			if (isHidden) {
				startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			}
			startInfo.FileName = name;
			startInfo.Arguments = command;
			process.StartInfo = startInfo;
			process.Start();
		}
	}
}