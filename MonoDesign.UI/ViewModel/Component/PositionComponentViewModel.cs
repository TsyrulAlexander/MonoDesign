using System.ComponentModel;
using Microsoft.Xna.Framework;
using MonoDesign.Component;
using MonoDesign.Core.Utilities;
using MonoDesign.UI.Component.Component;

namespace MonoDesign.UI.ViewModel.Component {
	public class PositionComponentViewModel : BaseComponentViewModel<PositionComponent> {
		public float X {
			get => Value.Position.X;
			set {
				if (value.IsEqual(Value.Position.X)) {
					return;
				}
				Value.Position = new Vector2(value, Value.Position.Y);
				OnPropertyChanged();
			}
		}
		public float Y {
			get => Value.Position.Y;
			set {
				if (value.IsEqual(Value.Position.Y)) {
					return;
				}
				Value.Position = new Vector2(Value.Position.X, value);
				OnPropertyChanged();
			}
		}
		public override void SetValue(object value) {
			base.SetValue(value);
			OnPositionChanged();
			Value.PropertyChanged += ValueOnPropertyChanged;
		}
		private void ValueOnPropertyChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == nameof(Value.Position)) {
				OnPositionChanged();
			}
		}
		protected virtual void OnPositionChanged() {
			OnPropertyChanged(nameof(X));
			OnPropertyChanged(nameof(Y));
		}
	}
}
