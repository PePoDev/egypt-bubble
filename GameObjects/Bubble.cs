using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GP_Midterm_BubblePuzzle {
	public class Bubble : _GameObject {
		public float Speed;
		public float Angle;

		public Bubble(Texture2D texture) : base(texture) {
		}

		public override void Update(GameTime gameTime, List<_GameObject> _GameObjects) {
			Velocity.X = (float)Math.Cos(Angle) * Speed;
			Velocity.Y = (float)Math.Sin(Angle) * Speed;

			Position += Velocity * gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;
			
			foreach (_GameObject g in _GameObjects) {
				if (g.Name.Equals("Player") && IsTouchingTop(g)) {
					//change angle according to where the ball hits the paddle
					Rectangle paddleRect = g.Rectangle;
					int collidedPointSegment = (int)((Position.X + Rectangle.Width / 2 - paddleRect.X) / paddleRect.Width * 8);
					switch (collidedPointSegment) {
						case 0:
							Angle = MathHelper.ToRadians(-150);
							break;
						case 1:
							Angle = MathHelper.ToRadians(-135);
							break;
						case 2:
							Angle = MathHelper.ToRadians(-120);
							break;
						case 3:
							Angle = MathHelper.ToRadians(-105);
							break;
						case 4:
							Angle = MathHelper.ToRadians(-60);
							break;
						case 5:
							Angle = MathHelper.ToRadians(-45);
							break;
						case 6:
							Angle = MathHelper.ToRadians(-30);
							break;
						case 7:
							Angle = MathHelper.ToRadians(-15);
							break;
					}
				}
				base.Update(gameTime, _GameObjects);
			}
			
			if (Position.Y <= 0 || Position.Y + _texture.Height >= Singleton.HEIGHT) {
				Angle = -Angle;
			}
			if (Position.Y + _texture.Height >= Singleton.HEIGHT) {
				Singleton.Instance.CurrentGameState = Singleton.GameState.GameEnded;

			}

			if (Position.X <= 0) {
				Angle = -Angle;
				Angle += MathHelper.ToRadians(180);
			}

			if (Position.X + _texture.Width >= Singleton.WIDTH) {
				Angle = -Angle;
				Angle += MathHelper.ToRadians(180);
			}
		}

		public override void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(_texture, Position, Color.White);
			base.Draw(spriteBatch);
		}

		public override void Reset() {
			Angle = MathHelper.ToRadians(-90);
			Speed = 300;
			Position = new Vector2(390,420);
			base.Reset();
		}
	}
}
