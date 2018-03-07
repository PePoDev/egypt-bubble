using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GP_Midterm_BubblePuzzle.Managers;

namespace GP_Midterm_BubblePuzzle.Screen {
	class SplashScreen : _GameScreen{
		private Vector2 fontSize;
		private Color _Color; // for update color alpha
		private SpriteFont Arial, Arcanista, KHMetropolis;
		private Texture2D Logo, GameName, Black;
		private int alpha; // Value of alpha in color for fade logo and text
		private int displayIndex; // order of index to display splash screen
		private float _timer; // Elapsed time in game
		private float _timePerUpdate; // Will do update function when _timer > _timePerUpdate
		private bool Show; // true will fade in and false will fade out

		public SplashScreen() {
			Show = true;
			_timePerUpdate = 0.05f;
			displayIndex = 0;
			alpha = 0;
			_Color = new Color(255,255,255,alpha);
		}
		public override void LoadContent() {
			base.LoadContent();
			Arcanista = content.Load<SpriteFont>("Fonts/Arcanista");
			Logo = content.Load<Texture2D>("SplashScreen/Logo");
			GameName = content.Load<Texture2D>("SplashScreen/Logo");
			Black = content.Load<Texture2D>("SplashScreen/Black");
		}
		public override void UnloadContent() { base.UnloadContent(); }
		public override void Update(GameTime gameTime) {
			// Add elapsed time to _timer
			_timer += (float)gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;
			if (_timer >= _timePerUpdate) {
				if (Show) {
					//fade in
					alpha += 5;
					// when fade in finish
					if (alpha >= 250) {
						Show = false;
						// transition screen
						if (displayIndex == 3) ScreenManager.Instance.LoadScreen(ScreenManager.GameScreenName.MenuScreen);
					}
				} else {
					// fade out
					alpha -= 5;
					// whene fade out finish
					if (alpha <= 0) {
						Show = true;
						// Change display index and set next display
						displayIndex++;
						if (displayIndex == 1) {
							_Color = Color.Black;
							_timePerUpdate -= 0.015f;
						} else if (displayIndex == 2) {
							_Color = Color.White;
						} else if (displayIndex == 3) {
							_timePerUpdate -= 0.02f;
						}
					}
				}
				_timer -= _timePerUpdate;
				_Color.A = (byte)alpha;
			}
			base.Update(gameTime);
		}
		public override void Draw(SpriteBatch spriteBatch) {
			switch (displayIndex) {
				case 0:
					spriteBatch.Draw(Logo, new Vector2((Singleton.Instance.Diemensions.X - Logo.Width) / 2, (Singleton.Instance.Diemensions.Y - Logo.Height) / 2), _Color);
					break;
				case 1:
					fontSize = Arcanista.MeasureString("proudly   present");
					spriteBatch.DrawString(Arcanista, "proudly   present", new Vector2((Singleton.Instance.Diemensions.X - fontSize.X)/2, (Singleton.Instance.Diemensions.Y - fontSize.Y) / 2), _Color);
					break;
				case 2:
					spriteBatch.Draw(GameName, new Vector2((Singleton.Instance.Diemensions.X - GameName.Width) / 2, (Singleton.Instance.Diemensions.Y - GameName.Height) / 2), _Color);
					break;
				case 3:
					spriteBatch.Draw(Black, Vector2.Zero, _Color);
					break;
			}
			
		}
	}
}
