using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GP_Midterm_BubblePuzzle.GameObjects {
	public class Bubble : _GameObject {
		public float Speed;
		public float Angle;
		public Vector2 Center { get; set; }
		public float Radius { get; set; }

		public Bubble(Texture2D texture) : base(texture) {
			Radius = Position.X / 2;
		}

		public override void Update(GameTime gameTime, _GameObject[,] gameObjects) {
			Center = new Vector2(Position.X / 2, Position.Y / 2);
			if (IsActive) {
				Console.WriteLine(Center.X + " : " + Center.Y);
				Velocity.X = (float)Math.Cos(Angle) * Speed;
				Velocity.Y = (float)Math.Sin(Angle) * Speed;
				Position += Velocity * gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;
			}
			foreach (Bubble g in gameObjects) {
				if ((g != null && !g.IsActive) && Intersects(g)) {
					IsActive = false;
					Console.WriteLine("STOP !!!!!!!!!!");
				}
			}

			if (Position.Y <= 40) {

			}

			if (Position.X <= 320) {
				Angle = -Angle;
				Angle += MathHelper.ToRadians(180);
			}

			if (Position.X + _texture.Width >= 960) {
				Angle = -Angle;
				Angle += MathHelper.ToRadians(180);
			}
		}

		public override void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(_texture, Position, color);
			base.Draw(spriteBatch);
		}

		public bool Intersects(Bubble other) {
			return ((other.Center - Center).Length() < (other.Radius - Radius));
		}
	}
}