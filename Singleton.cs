using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GP_Midterm_BubblePuzzle {
	 class Singleton {
		public Vector2 Diemensions = new Vector2(1280,720);
		public int TILESIZE = 75;
		public int BGM_MasterVolume = 100;
		public int SFX_MasterVolume = 100;
		public bool cmdExit = false, cmdFullScreen = false, cmdShowFPS = false;

		public MouseState MousePrevious, MouseCurrent;

		private static Singleton instance;
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
