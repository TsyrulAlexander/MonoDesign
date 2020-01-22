using System;

namespace MonoDesign.Component.Script {
	[AttributeUsage(AttributeTargets.Class)]
	public class ScriptAttribute : System.Attribute {
		public string Caption { get; set; }
		public ScriptAttribute(string caption) {
			Caption = caption;
		}

	}
}
