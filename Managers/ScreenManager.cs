using GP_Midterm_BubblePuzzle.Screen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GP_Midterm_BubblePuzzle.Managers {
	public class ScreenManager {
		public ContentManager Content { private set; get; }
		public enum GameScreenName {
			MenuScreen,
			PalyScreen
		}
		private _GameScreen CurrentGameScreen;

		public ScreenManager() {
			CurrentGameScreen = new SplashScreen();
		}
		public void LoadScreen(GameScreenName _ScreenName) {
			//CurrentGameScreen.UnloadContent();
			switch (_ScreenName) {
				case GameScreenName.MenuScreen:
					CurrentGameScreen = new MenuScreen();
					break;
				case GameScreenName.PalyScreen:
					CurrentGameScreen = new PlayScreen();
					break;
			}
			CurrentGameScreen.LoadContent();
		}
		public void LoadContent(ContentManager Content) {
			this.Content = new ContentManager(Content.ServiceProvider, "Content");
			CurrentGameScreen.LoadContent();
		}
		public void UnloadContent() {
			CurrentGameScreen.UnloadContent();
		}

		public void Update(GameTime gameTime) {
			CurrentGameScreen.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch) {
			CurrentGameScreen.Draw(spriteBatch);
		}
		private static ScreenManager instance;
		public static ScreenManager Instance {
			get {
				if (instance == null)
					instance = new ScreenManager();
				return instance;
			}
		}
	}
}
