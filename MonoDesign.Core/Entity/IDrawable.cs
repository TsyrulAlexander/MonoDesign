using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoDesign.Core.Entity {
	public interface IDrawable {
		bool IsDrawable { get; set; }
		Texture2D Texture { get; set; }
		Vector2 Position { get; set; }
		Rectangle? SourceRectangle { get; set; }
		Color Color { get; set; }
		float Rotation { get; set; }
		Vector2 Origin { get; set; }
		Vector2 Scale { get; set; }
		SpriteEffects Effects { get; set; }
		float LayerDepth { get; set; }
		void Draw(GameTime gameTime);
	}
}