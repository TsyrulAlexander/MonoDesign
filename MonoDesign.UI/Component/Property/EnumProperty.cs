namespace MonoDesign.UI.Component.Property {
	public class EnumProperty<T> : BaseProperty<T> {
		public EnumProperty(string caption, bool isRequired = false, object tag = null) :
			base(caption, isRequired, tag) {
		}
	}
}
