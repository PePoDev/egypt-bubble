using Microsoft.Xna.Framework.Input;
using GP_Midterm_BubblePuzzle.Managers;

namespace GP_Midterm_BubblePuzzle {
	 class Singleton {
		public const int WIDTH = 1280;
		public const int HEIGHT = 720;
		public const int TILESIZE = 75;

		public bool alive = true;
		public float delTimePerBlock = 0.5f;
		public float TimePerBlock = 0.5f;
		public long _timer;

		public float MasterBGMVolume;
		public float MasterSFXVolume;

		public enum GameState {
			WaitPlayerShootBall,
			GamePlaying,
			GameEnded,
			GameOver
		}
		public GameState CurrentGameState;

		public KeyboardState PreviousKey, CurrentKey;

		private static Singleton instance;
		private Singleton() { }
		public static Singleton Instance {
			get {
				if (instance == null) {
					instance = new Singleton();
				}
				return instance;
			}
		}
	}
}
