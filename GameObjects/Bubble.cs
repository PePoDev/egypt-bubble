using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GP_Midterm_BubblePuzzle.GameObjects {
	public class Bubble : _GameObject {
		public float Speed;
		public float Angle;

		public Bubble(Texture2D texture) : base(texture) {
		}

		public override void Update(GameTime gameTime, Bubble[,] gameObjects) {
			if (IsActive) {
				Velocity.X = (float)Math.Cos(Angle) * Speed;
				Velocity.Y = (float)Math.Sin(Angle) * Speed;
				Position += Velocity * gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;
				DetectCollision(gameObjects);
				
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

		private void DetectCollision(Bubble[,] gameObjects) {
			for (int i = 0; i < 9; i++) {
				for (int j = 0; j < 8; j++) {
					if (gameObjects[i, j] != null && !gameObjects[i, j].IsActive) {
						if (CheckCollision(gameObjects[i, j]) <= 80) {
							Console.WriteLine(j + " : " + i);
							if (Position.X >= gameObjects[i, j].Position.X) {
								gameObjects[i+1, j+1] = this;
								Console.WriteLine("Right !!");
								//Console.WriteLine(j + " : " + i);
							} else {
								gameObjects[i + 1, j] = this;
								Console.WriteLine("Left !!");
								//Console.WriteLine(j + " : " + i);
							}
							IsActive = false;
							Singleton.Instance.Shooting = false;
							return;
						}

					}
				}
			}
		}
		public override void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(_texture, Position, color);
			base.Draw(spriteBatch);
		}

		public int CheckCollision(Bubble other) {
			return (int)Math.Sqrt(Math.Pow(Position.X - other.Position.X, 2) + Math.Pow(Position.Y - other.Position.Y, 2));
		}
	}
}