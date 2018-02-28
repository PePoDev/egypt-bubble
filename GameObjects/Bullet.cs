using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GP_Midterm_BubblePuzzle.GameObjects;

namespace GP_Midterm_BubblePuzzle {
	public class Bullet : _GameObject {
		public float DistanceMoved;

		public Bullet(Texture2D texture) : base(texture) {
		}

		public override void Update(GameTime gameTime, List<_GameObject> gameObjects) {
			DistanceMoved += Math.Abs(Velocity.Y * gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond);
			Position = Position + Velocity * gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;

			if (DistanceMoved >= Singleton.HEIGHT)
				IsActive = false;

			base.Update(gameTime, gameObjects);
		}

		public override void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(_texture,
							Position,
							Viewport,
							Color.White);

			base.Draw(spriteBatch);
		}

		public override void Reset() {
			DistanceMoved = 0;
			base.Reset();
		}
	}
}
