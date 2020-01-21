namespace MonoDesign.UI.Component.Property {
	public class BooleanProperty : BaseProperty<bool> {
		public BooleanProperty(string caption, bool isRequired = false, object tag = null) : base(caption, isRequired,
			tag) {
		}
	}
}
