using System.Runtime.Serialization;

namespace MonoDesign.Core.Serialization {
	public interface IGameSerializable {
		void Serialize(object obj, SerializationInfo info, StreamingContext context);
		object Deserialize(object obj, SerializationInfo info, StreamingContext context);
	}
}