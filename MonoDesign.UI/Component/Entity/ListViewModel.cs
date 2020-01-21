using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MonoDesign.UI.Component.Entity {
	public class ListViewModel<T> : Core.VM.ViewModel where T : class {
		private T _currentItem;
		private ObservableCollection<T> _items;
		public T CurrentItem {
			get => _currentItem;
			set {
				if (Equals(value, _currentItem))
					return;
				_currentItem = value;
				OnPropertyChanged();
			}
		}
		public List<T> SelectedItems { get; }
		public ObservableCollection<T> Items {
			get => _items;
			set {
				if (Equals(value, _items))
					return;
				_items = value;
				OnPropertyChanged();
			}
		}
		public ListViewModel(ObservableCollection<T> collection = null) {
			Items = collection ?? new ObservableCollection<T>();
			SelectedItems = new List<T>();
		}
		public void Clear() {
			CurrentItem = null;
			SelectedItems.Clear();
			Items.Clear();
		}
	}
}
