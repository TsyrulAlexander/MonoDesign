using System;
using System.Windows.Input;
using MonoDesign.Component;
using MonoDesign.Component.Attribute;
using MonoDesign.Core;
using MonoDesign.Core.Entity.Component;
using MonoDesign.Core.Entity.GameObject;
using MonoDesign.Core.Entity.Reflection;
using MonoDesign.Core.Messages;
using MonoDesign.UI.Component.Command;
using MonoDesign.UI.Component.Entity;

namespace MonoDesign.UI.ViewModel {
	public class GameObjectPropertyViewModel : Core.VM.ViewModel {
		private readonly IMessenger _messenger;
		private IGameObject _gameObject;
		public IGameObject GameObject {
			get => _gameObject;
			set {
				if (Equals(value, _gameObject))
					return;
				_gameObject = value;
				OnPropertyChanged();
			}
		}
		public ListViewModel<AttributeInfo<ComponentAttribute>> AllComponentList { get; private set; }
		public ICommand AddComponentCommand { get; set; }
		public GameObjectPropertyViewModel(IMessenger messenger) {
			_messenger = messenger;
			AddComponentCommand = new RelayCommand(AddComponentExecute, AddComponentCanExecute);
		}
		private bool AddComponentCanExecute() {
			return GameObject != null && AllComponentList.CurrentItem != null;
		}
		private void AddComponentExecute() {
			var attributeInfo = AllComponentList.CurrentItem;
			var componentType = attributeInfo.Type;
			var component = (IGameObjectComponent)GameServices.GetService(componentType);
			component.Initialize(GameObject);
			GameObject.Components.Add(component);
		}

		public override void Initialize() {
			base.Initialize();
			_messenger.Subscribe<IGameObject>("SelectedGameObjectChanged", SelectedGameObjectChanged);
			AllComponentList = new ListViewModel<AttributeInfo<ComponentAttribute>>();
			InitComponents();
		}
		protected virtual void InitComponents() {
			var components = ComponentUtilities.GetComponents();
			foreach (var component in components) {
				AllComponentList.Items.Add(component);
			}
		}
		private void SelectedGameObjectChanged(IGameObject obj) {
			GameObject = obj;
		}
	}
}