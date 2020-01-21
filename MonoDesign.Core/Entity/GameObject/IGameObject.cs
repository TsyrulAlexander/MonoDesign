using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Core.Entity.Component;
using MonoDesign.Core.Serialization;

namespace MonoDesign.Core.Entity.GameObject {
	public interface IGameObject : ILookup, IComponentUser, IUpdatable, IDrawable, IGameSerializable,
		INotifyPropertyChanged {
		Texture2D Texture { get; set; }
		Vector2 Position { get; set; }
		Rectangle? SourceRectangle { get; set; }
		Color Color { get; set; }
		float Rotation { get; set; }
		Vector2 Origin { get; set; }
		Vector2 Scale { get; set; }
		SpriteEffects Effects { get; set; }
		float LayerDepth { get; set; }
		void Initialize();
	}
}
