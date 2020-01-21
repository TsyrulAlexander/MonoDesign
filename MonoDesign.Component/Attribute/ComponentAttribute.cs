using System;

namespace MonoDesign.Component.Attribute
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ComponentAttribute : System.Attribute {
		public string Caption { get; set; }
		public ComponentAttribute(string caption) {
			Caption = caption;
		}
	}
}