using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GP_Midterm_BubblePuzzle.Screen {
	class MenuScreen : _GameScreen {
		private Color _Color = new Color(250, 250, 250, 0);
		private Texture2D BG, Black;

		private bool fadeFinish = false;
		private bool showOption = false, showRanking = false, showAbout = false;
		private bool mhStart = false, mhOption = false, mhAbout = false, mhRanking = false, mhExit = false;

		private float _timer = 0.0f;
		private float timerPerUpdate = 0.03f;
		private int alpha = 255;
		
		public override void LoadContent() {
			base.LoadContent();
			BG = content.Load<Texture2D>("MenuScreen/BG");
			Black = content.Load<Texture2D>("SplashScreen/Black");
		}
		public override void UnloadContent() {
			base.UnloadContent();
		}
		public override void Update(GameTime gameTime) {
			// Menu click
			Singleton.Instance.MousePrevious = Singleton.Instance.MouseCurrent;
			Singleton.Instance.MouseCurrent = Mouse.GetState();
			if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
				// Click start game
				if ((Singleton.Instance.MouseCurrent.X > 0 && Singleton.Instance.MouseCurrent.Y > 0) && (Singleton.Instance.MouseCurrent.X < 100 && Singleton.Instance.MouseCurrent.Y < 100)) {

				} // Click option
				else if ((Singleton.Instance.MouseCurrent.X > 0 && Singleton.Instance.MouseCurrent.Y > 0) && (Singleton.Instance.MouseCurrent.X < 100 && Singleton.Instance.MouseCurrent.Y < 100)) {

				} // Click About
				else if ((Singleton.Instance.MouseCurrent.X > 0 && Singleton.Instance.MouseCurrent.Y > 0) && (Singleton.Instance.MouseCurrent.X < 100 && Singleton.Instance.MouseCurrent.Y < 100)) {

				} // Click Ranking
				else if ((Singleton.Instance.MouseCurrent.X > 0 && Singleton.Instance.MouseCurrent.Y > 0) && (Singleton.Instance.MouseCurrent.X < 100 && Singleton.Instance.MouseCurrent.Y < 100)) {

				} // Click Exit
				else if ((Singleton.Instance.MouseCurrent.X > 0 && Singleton.Instance.MouseCurrent.Y > 0) && (Singleton.Instance.MouseCurrent.X < 100 && Singleton.Instance.MouseCurrent.Y < 100)) {
					
				}
			}
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
			// Draw mouse hover on button


			// Draw fade out
			if (!fadeFinish) {
				spriteBatch.Draw(Black, Vector2.Zero, _Color);
			}
		}
	}
}
