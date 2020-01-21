using System.ComponentModel;
using System.Runtime.CompilerServices;
using MonoDesign.Core.Annotations;

namespace MonoDesign.Core.VM {
	public class ViewModel : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;
		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public virtual void Initialize() { }
	}
}