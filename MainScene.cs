using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using GP_Midterm_BubblePuzzle.Managers;

namespace GP_Midterm_BubblePuzzle {

	public class MainScene : Game {
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;

		private Texture2D Bubble;
		private SpriteFont Arial, Arcanista, KHMetropolis;
		private List<_GameObject> _gameObjects;
		private int _numObject;

		private FrameCounter _frameCounter;
		private SceneManager sceneManager;

		private Song _bgm;
		public MainScene() {
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferHeight = Singleton.HEIGHT;
			graphics.PreferredBackBufferWidth = Singleton.WIDTH;
			graphics.SynchronizeWithVerticalRetrace = false;
			IsFixedTimeStep = false;
			Content.RootDirectory = "Content";
			graphics.ApplyChanges();
		}

		protected override void Initialize() {
			_frameCounter = new FrameCounter();
			sceneManager = new SceneManager();
			_gameObjects = new List<_GameObject>();

			Reset();
			base.Initialize();
		}
		private void Reset() {

		}

		protected override void LoadContent() {
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Arial = Content.Load<SpriteFont>("Fonts/Arial");
			Arcanista = Content.Load<SpriteFont>("Fonts/Arcanista");
			KHMetropolis = Content.Load<SpriteFont>("Fonts/KH-Metropolis");

		}

		protected override void UnloadContent() {}
		
		protected override void Update(GameTime gameTime) {
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			Singleton.Instance.CurrentKey = Keyboard.GetState();

			switch (sceneManager.getCurrentScene()) {
				case SceneManager.SceneName.MainMenu:
					if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Escape) && !Singleton.Instance.CurrentKey.Equals(Singleton.Instance.PreviousKey)) {
						
					}
						break;
				case SceneManager.SceneName.PalyGame:
					break;
				case SceneManager.SceneName.ScoreBoard:
					break;
				case SceneManager.SceneName.Option:
					break;
				case SceneManager.SceneName.About:
					break;
			}
			
			Singleton.Instance.PreviousKey = Singleton.Instance.CurrentKey;
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin();

			sceneManager.Update(spriteBatch);

			float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			_frameCounter.Update(deltaTime);
			spriteBatch.DrawString(Arial,string.Format("FPS: {0}", _frameCounter.AverageFramesPerSecond), new Vector2(1, 1), Color.Black);

			spriteBatch.End();
			graphics.BeginDraw();
			base.Draw(gameTime);
		}
		
	}
}
