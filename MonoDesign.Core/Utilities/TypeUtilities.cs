using System;
using System.Collections.Generic;
using System.Text;

namespace MonoDesign.Core.Utilities
{
	public static class TypeUtilities
	{
		public static bool IsEqual(this float value1, float value2) {
			return Math.Abs(value1 - value2) < 0.0000;
		}
	}
}
