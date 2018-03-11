using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_Midterm_BubblePuzzle.GameObjects {
	class Gun : _GameObject {
		private Random random = new Random();
		private Texture2D bubbleTexture;
		private Bubble BubbleOnGun;
		private Color _color;
		private float angle;

		public Gun(Texture2D texture, Texture2D bubble) : base(texture) {
			bubbleTexture = bubble;
			_color = GetRandomColor();
		}

		public override void Update(GameTime gameTime, Bubble[,] gameObjects) {
			// TODO : Click to shoot bubble
			Singleton.Instance.MousePrevious = Singleton.Instance.MouseCurrent;
			Singleton.Instance.MouseCurrent = Mouse.GetState();
			if (Singleton.Instance.MouseCurrent.Y < 625) {
				angle = (float)Math.Atan2((Position.Y + _texture.Height / 2) - Singleton.Instance.MouseCurrent.Y, (Position.X + _texture.Width / 2) - Singleton.Instance.MouseCurrent.X);
				if (!Singleton.Instance.Shooting && Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
					BubbleOnGun = new Bubble(bubbleTexture) {
						Name = "Bubble",
						Position = new Vector2(Singleton.Instance.Diemensions.X / 2 - bubbleTexture.Width / 2, 700 - bubbleTexture.Height),
						color = _color,
						IsActive = true,
						Angle = angle + MathHelper.Pi,
						Speed = 500,
					};
					_color = GetRandomColor();
					Singleton.Instance.Shooting = true;
				}
			}
			if (Singleton.Instance.Shooting)
				BubbleOnGun.Update(gameTime, gameObjects);
		}
		public override void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(_texture, Position + new Vector2(50, 50), null, Color.White, angle + MathHelper.ToRadians(-90f), new Vector2(50, 50), 1.5f, SpriteEffects.None, 0f);
			if (!Singleton.Instance.Shooting)
				spriteBatch.Draw(bubbleTexture, new Vector2(Singleton.Instance.Diemensions.X / 2 - bubbleTexture.Width / 2, 700 - bubbleTexture.Height),_color);
			else
				BubbleOnGun.Draw(spriteBatch);
		}
		public Color GetRandomColor() {
			Color _color = Color.Black;
			switch (random.Next(0, 6)) {
				case 0:
					_color = Color.White;
					break;
				case 1:
					_color = Color.Blue;
					break;
				case 2:
					_color = Color.Yellow;
					break;
				case 3:
					_color = Color.Red;
					break;
				case 4:
					_color = Color.Green;
					break;
				case 5:
					_color = Color.Purple;
					break;
			}
			return _color;
		}
	}
}
