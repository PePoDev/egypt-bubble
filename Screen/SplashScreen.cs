using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GP_Midterm_BubblePuzzle.Managers;

namespace GP_Midterm_BubblePuzzle.Scene {
	class SplashScreen : _GameScreen{
		private Vector2 _Position;
		private Color _Color;
		private Texture2D Logo, Present, GameName;
		private int alpha;
		private int displayIndex;
		private float _timer;
		private float _timePerUpdate;
		private bool Show;

		public SplashScreen() {
			Show = true;
			_timePerUpdate = 0.025f;
			displayIndex = 0;
			alpha = 0;
			_Position = new Vector2(440,230);
			_Color = new Color(255,255,255,alpha);
		}
		public override void LoadContent() {
			base.LoadContent();
			Logo = content.Load<Texture2D>("SplashScreen/Logo");
			Present = content.Load<Texture2D>("SplashScreen/Logo");
			GameName = content.Load<Texture2D>("SplashScreen/Logo");
		}
		public override void UnloadContent() {
			base.UnloadContent();
		}
		public override void Update(GameTime gameTime) {
			_timer += (float)gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;
			if (_timer >= _timePerUpdate) {
				if (Show) {
					alpha += 5;
					if (alpha >= 250) {
						Show = false;
					}
				} else {
					alpha -= 5;
					if (alpha <= 0) {
						Show = true;
						if (++displayIndex == 3) {
							ScreenManager.Instance.LoadScreen(ScreenManager.GameScreenName.MenuScreen);
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
					spriteBatch.Draw(Logo, _Position, _Color);
					break;
				case 1:
					spriteBatch.Draw(Present, _Position, _Color);
					break;
				case 2:
					spriteBatch.Draw(GameName, _Position, _Color);
					break;
			}
			
		}
	}
}
