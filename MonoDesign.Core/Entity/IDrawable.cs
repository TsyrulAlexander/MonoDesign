using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoDesign.Core.Entity {
	public interface IDrawable {
		bool IsDrawable { get; set; }
		void Draw(GameTime gameTime);
	}
}