using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GP_Midterm_BubblePuzzle.Managers {
	public class SceneManager {
		public enum SceneName {
			MainMenu,
			PalyGame,
			ScoreBoard,
			Option,
			About
		}
		private SceneName _SceneName;

		public SceneName getCurrentScene() {
			return _SceneName;
		}

		public bool loadScene(SceneName _SN) {
			_SceneName = _SN;
			return true;
		}

		public void Update(SpriteBatch spriteBatch) {
			switch (getCurrentScene()) {
				case SceneName.MainMenu:
					//spriteBatch.Draw(, , new Vector2(1, 1), Color.Black);
					break;
				case SceneName.PalyGame:
					break;
				case SceneName.ScoreBoard:
					break;
				case SceneName.Option:
					break;
				case SceneName.About:
					break;
			}
			
		}
	}
}
