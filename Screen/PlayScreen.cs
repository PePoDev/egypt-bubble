using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GP_Midterm_BubblePuzzle.GameObjects;
using System;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace GP_Midterm_BubblePuzzle.Screen {
	class PlayScreen : _GameScreen {
		private Texture2D BG, Black, BubbleTexture, GunTexture;
		private SpriteFont Arial, Arcanista;
		private Bubble[,] bubble = new Bubble[9, 8];
		private Color _Color;
		private Random random = new Random();
		private Gun gun;
		private Vector2 fontSize;
		private float _timer = 0f;
		private float Timer = 0f;
		private float timerPerUpdate = 0.05f;
		private int alpha = 255;
		private bool fadeFinish = false;

		public void Initial() {
			_Color = new Color(255, 255, 255, alpha);
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 8 - (i%2); j++) {
					bubble[i, j] = new Bubble(BubbleTexture) {
						Name = "Bubble",
						Position = new Vector2((j * 80) + ((i % 2) == 0 ? 320 : 360), (i * 70) + 40),
						color = GetRandomColor(),
						IsActive = false,
					};
				}
			}
			gun = new Gun(GunTexture,BubbleTexture) {
				Name = "Gun",
				Position = new Vector2(Singleton.Instance.Diemensions.X/2 - GunTexture.Width / 2, 700 - GunTexture.Height),
				color = Color.White,
				IsActive = true,
			};
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
		public override void LoadContent() {
			base.LoadContent();
			BG = content.Load<Texture2D>("PlayScreen/BG");
			Black = content.Load<Texture2D>("SplashScreen/Black");
			BubbleTexture = content.Load<Texture2D>("PlayScreen/bubble_sheet");
			GunTexture = content.Load<Texture2D>("PlayScreen/bow_sheet");
			Arial = content.Load<SpriteFont>("Fonts/Arial");
			Arcanista = content.Load<SpriteFont>("Fonts/Arcanista");
			Initial();
		}
		public override void UnloadContent() {
			base.UnloadContent();
		}
		public override void Update(GameTime gameTime) {
			for (int i = 0; i < 9; i++) {
				for (int j = 0; j < 8; j++) {
					if (bubble[i, j] != null)
						bubble[i, j].Update(gameTime, bubble);
				}
			}
			gun.Update(gameTime, bubble);

			Timer += (float)gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;

			// fade out
			if (!fadeFinish) {
				_timer += (float)gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;
				if (_timer >= timerPerUpdate) {
					alpha -= 5;
					_timer -= timerPerUpdate;
					if (alpha <= 5) {
						fadeFinish = true;
					}
					_Color.A = (byte)alpha;
				}
			}
			
			base.Update(gameTime);
		}
		public override void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(BG, Vector2.Zero, Color.White);
			for (int i = 0; i < 9; i++) {
				for (int j = 0; j < 8; j++) {
					if (bubble[i,j] != null)
						bubble[i, j].Draw(spriteBatch);
				}
			}
			gun.Draw(spriteBatch);

			fontSize = Arcanista.MeasureString("Score : " + Singleton.Instance.Score);
			spriteBatch.DrawString(Arcanista, "Score : " + Singleton.Instance.Score, new Vector2(0,0), _Color);

			fontSize = Arcanista.MeasureString("Time : " + Timer);
			spriteBatch.DrawString(Arcanista, "Time : " + Timer, new Vector2(0, 360), _Color);

			// Draw fade out
			if (!fadeFinish) {
				spriteBatch.Draw(Black, Vector2.Zero, _Color);
			}
		}
	}
}
