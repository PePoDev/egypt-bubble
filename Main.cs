using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using GP_Midterm_BubblePuzzle.Managers;

namespace GP_Midterm_BubblePuzzle {

	public class Main : Game {
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private Song BGM;
		private SpriteFont Arial;

		public Main() {
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = (int)Singleton.Instance.Diemensions.X;
			graphics.PreferredBackBufferHeight = (int)Singleton.Instance.Diemensions.Y;
			graphics.SynchronizeWithVerticalRetrace = false;
			IsFixedTimeStep = false;
			IsMouseVisible = true;
			Content.RootDirectory = "Content";
			Window.Position = new Point((GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - (graphics.PreferredBackBufferWidth / 2), (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - (graphics.PreferredBackBufferHeight / 2));
			graphics.ApplyChanges();
		}

		protected override void Initialize() {
			BGM = Content.Load<Song>("Audios/Spirit_of_the_Dead");
			MediaPlayer.IsRepeating = true;
			MediaPlayer.Volume = Singleton.Instance.BGM_MasterVolume;
			MediaPlayer.Play(BGM);
			base.Initialize();
		}

		protected override void LoadContent() {
			spriteBatch = new SpriteBatch(GraphicsDevice);
			ScreenManager.Instance.LoadContent(Content);
			Arial = Content.Load<SpriteFont>("Fonts/Arial");
		}

		protected override void UnloadContent() {
			ScreenManager.Instance.UnloadContent();
		}

		protected override void Update(GameTime gameTime) {
			ScreenManager.Instance.Update(gameTime);
			Singleton.Instance.IsFullScreen = graphics.IsFullScreen;
			MediaPlayer.Volume = Singleton.Instance.BGM_MasterVolume;

			if (Singleton.Instance.cmdExit) {
				Exit();
			}
			if (Singleton.Instance.cmdFullScreen) {
				graphics.ToggleFullScreen();
				graphics.ApplyChanges();
				Singleton.Instance.cmdFullScreen = false;
			}
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.White);
			spriteBatch.Begin();

			ScreenManager.Instance.Draw(spriteBatch);
			if (Singleton.Instance.cmdShowFPS) {
				float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
				FrameCounter.Instance.Update(deltaTime);
				spriteBatch.DrawString(Arial, string.Format("FPS: " + FrameCounter.Instance.AverageFramesPerSecond.ToString("F")), new Vector2(1090,10), Color.Yellow);
			}

			spriteBatch.End();
			base.Draw(gameTime);
		}

	}
}
