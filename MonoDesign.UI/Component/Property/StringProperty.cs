

namespace MonoDesign.UI.Component.Property {
	public class StringProperty : BaseProperty<string> {

		public StringProperty(string caption, bool isRequired = false, object tag = null) : base(caption, isRequired,
			tag) {
		}

		public override bool IsValid(out string message) {
			if (IsRequired && string.IsNullOrWhiteSpace(Value)) {
				//message = string.Format(Resources.IsEmpryPropertyValueMessage, Caption);
				message = string.Empty;
				return false;
			}
			return base.IsValid(out message);
		}
	}
}