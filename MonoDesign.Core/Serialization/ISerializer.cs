namespace MonoDesign.Core.Serialization {
	public interface ISerializer {
		byte[] SerializeData(IGameSerializable obj);
		T DeserializeData<T>(byte[] bytes) where T : IGameSerializable;
	}
}
