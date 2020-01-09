using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using MonoDesign.Core.Entity;
using MonoDesign.Core.Entity.GameObject;

namespace MonoDesign.Core.Serialization {
	public static class SerializeManager {
		public static SurrogateSelector GetSurrogateSelector() {
			var surrogateSelector = new SurrogateSelector();
			surrogateSelector.AddSurrogate(typeof(GameObject), new StreamingContext(StreamingContextStates.All),
				new SerializationSurrogate());
			surrogateSelector.AddSurrogate(typeof(Scene), new StreamingContext(StreamingContextStates.All),
				new SerializationSurrogate());
			return surrogateSelector;
		}
	}
}