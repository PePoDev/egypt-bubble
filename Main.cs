using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using GP_Midterm_BubblePuzzle.Managers;

namespace GP_Midterm_BubblePuzzle {

	public class Main : Game {
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private Song BGM;
		private SpriteFont Arial, Arcanista, KHMetropolis;

		public Main() {
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = (int)Singleton.Instance.Diemensions.X;
			graphics.PreferredBackBufferHeight = (int)Singleton.Instance.Diemensions.Y;
			graphics.SynchronizeWithVerticalRetrace = false;
			IsFixedTimeStep = false;
			IsMouseVisible = true;
			Content.RootDirectory = "Content";
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
			Arcanista = Content.Load<SpriteFont>("Fonts/Arcanista");
			KHMetropolis = Content.Load<SpriteFont>("Fonts/KH-Metropolis");
		}

		protected override void UnloadContent() {
			ScreenManager.Instance.UnloadContent();
		}
		
		protected override void Update(GameTime gameTime) {
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			Singleton.Instance.CurrentKey = Keyboard.GetState();

			ScreenManager.Instance.Update(gameTime);
			
			Singleton.Instance.PreviousKey = Singleton.Instance.CurrentKey;
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.White);
			spriteBatch.Begin();

			ScreenManager.Instance.Draw(spriteBatch);
			if (Singleton.Instance.showFPS) {
				float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
				FrameCounter.Instance.Update(deltaTime);
				spriteBatch.DrawString(Arcanista, string.Format("FPS: {0}", FrameCounter.Instance.AverageFramesPerSecond), new Vector2(1, 1), Color.Black);
			}

			spriteBatch.End();
			base.Draw(gameTime);
		}
		
	}
}
