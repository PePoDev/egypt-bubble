using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GP_Midterm_BubblePuzzle.Managers;
using System;

namespace GP_Midterm_BubblePuzzle.Screen {
	class MenuScreen : _GameScreen {
		private Color _Color = new Color(250, 250, 250, 0);
		private Texture2D BG, Black;
		private Texture2D StartH, AboutH, OptionH, RankingH, ExitH, checkBoxYes, checkBoxNo, apply, back;

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
			StartH = content.Load<Texture2D>("MenuScreen/start");
			AboutH = content.Load<Texture2D>("MenuScreen/about");
			OptionH = content.Load<Texture2D>("MenuScreen/option");
			RankingH = content.Load<Texture2D>("MenuScreen/ranking");
			ExitH = content.Load<Texture2D>("MenuScreen/exit");
			checkBoxYes = content.Load<Texture2D>("MenuScreen/checkBox-yes");
			checkBoxNo = content.Load<Texture2D>("MenuScreen/checkBox-no");
			apply = content.Load<Texture2D>("MenuScreen/apply");
			back = content.Load<Texture2D>("MenuScreen/back");
		}
		public override void UnloadContent() {
			base.UnloadContent();
		}
		public override void Update(GameTime gameTime) {
			// Menu click
			Singleton.Instance.MousePrevious = Singleton.Instance.MouseCurrent;
			Singleton.Instance.MouseCurrent = Mouse.GetState();
			
			// Click start game
			if ((Singleton.Instance.MouseCurrent.X > 517 && Singleton.Instance.MouseCurrent.Y > 166) && (Singleton.Instance.MouseCurrent.X < 780 && Singleton.Instance.MouseCurrent.Y < 514)) {
				mhStart = true;
				if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
					ScreenManager.Instance.LoadScreen(ScreenManager.GameScreenName.PalyScreen);
				}
			} else {
				mhStart = false;
			}
			// Click option
			if ((Singleton.Instance.MouseCurrent.X > 93 && Singleton.Instance.MouseCurrent.Y > 161) && (Singleton.Instance.MouseCurrent.X < 256 && Singleton.Instance.MouseCurrent.Y < 674)) {
				mhOption = true;
				if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {

				}
			} else {
				mhOption = false;
			}
			// Click About
			if ((Singleton.Instance.MouseCurrent.X > 1044 && Singleton.Instance.MouseCurrent.Y > 178) && (Singleton.Instance.MouseCurrent.X < 1218 && Singleton.Instance.MouseCurrent.Y < 694)) {
				mhAbout = true;
				if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {

				}
			} else {
				mhAbout = false;
			}
			// Click Ranking
			if ((Singleton.Instance.MouseCurrent.X > 978 && Singleton.Instance.MouseCurrent.Y > 30) && (Singleton.Instance.MouseCurrent.X < 1200 && Singleton.Instance.MouseCurrent.Y < 160)) {
				mhRanking = true;
				if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {

				}
			} else {
				mhRanking = false;
			}
			// Click Exit
			if ((Singleton.Instance.MouseCurrent.X > 420 && Singleton.Instance.MouseCurrent.Y > 580) && (Singleton.Instance.MouseCurrent.X < 831 && Singleton.Instance.MouseCurrent.Y < 692)) {
				mhExit = true;
				if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {

				}
			} else {
				mhExit = false;
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
			// Draw mouse onHover button
			if (mhAbout) {
				spriteBatch.Draw(AboutH, new Vector2(1047, 366), Color.White);
			}
			if (mhExit) {
				spriteBatch.Draw(ExitH, new Vector2(475, 574), Color.White);
			}
			if (mhOption) {
				spriteBatch.Draw(OptionH, new Vector2(98, 362), Color.White);
			}
			if (mhRanking) {
				spriteBatch.Draw(RankingH, new Vector2(986, 57), Color.White);
			}
			if (mhStart) {
				spriteBatch.Draw(StartH, new Vector2(551, 332), Color.White);
			}

			// Draw fade out
			if (!fadeFinish) {
				spriteBatch.Draw(Black, Vector2.Zero, _Color);
			}
		}
	}
}
