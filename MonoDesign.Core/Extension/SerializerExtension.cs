using MonoDesign.Core.Serialization;

namespace MonoDesign.Core.Extension {
	public static class SerializerExtension {
		public static void UseGameSerializer(this ServiceProvider provider) {
			provider.AddSingleton<ISerializer, BinarySerializer>();
		}
	}
}
