namespace MonoDesign.Core.Process
{
	public interface IProcessService {
		void StartProcess(string name, string command, bool isHidden = false, string workingDirectory = "");
	}
}
