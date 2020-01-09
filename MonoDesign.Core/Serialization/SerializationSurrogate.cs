using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MonoDesign.Core.Serialization
{
	public class SerializationSurrogate: ISerializationSurrogate {
		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context) {
			var item = (IGameSerializable) obj;
			item.Serialize(item, info, context);
		}
		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector) {
			var item = (IGameSerializable)obj;
			return item.Deserialize(item, info, context);
		}
	}
}
