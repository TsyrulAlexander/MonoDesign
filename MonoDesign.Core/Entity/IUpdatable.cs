using Microsoft.Xna.Framework;

namespace MonoDesign.Core.Entity
{
	public interface IUpdatable {
		bool IsUpdatable { get; set; }
		void Update(GameTime gameTime);
	}
}
