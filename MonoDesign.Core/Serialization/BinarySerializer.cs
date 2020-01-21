using MonoDesign.Core.Utilities;

namespace MonoDesign.Core.Serialization
{
	public class BinarySerializer: ISerializer {
		public byte[] SerializeData(IGameSerializable obj) {
			return obj.SerializeData();
		}
		public T DeserializeData<T>(byte[] bytes) where T : IGameSerializable {
			return bytes.DeserializeData<T>();
		}
	}
}
