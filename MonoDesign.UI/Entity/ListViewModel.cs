using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MonoDesign.UI.Entity
{
	public class ListViewModel<T>: Core.VM.ViewModel
	{
		private T _currentItem;
		public T CurrentItem {
			get => _currentItem;
			set {
				if (Equals(value, _currentItem))
					return;
				_currentItem = value;
				OnPropertyChanged();
			}
		}
		public ObservableCollection<T> Items { get; set; }
	}
}
