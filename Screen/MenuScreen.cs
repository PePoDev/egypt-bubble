using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_Midterm_BubblePuzzle.Scene {
	class MenuScreen :_GameScreen {
		private Texture2D BG;
		public override void LoadContent() {
			base.LoadContent();
			BG = content.Load<Texture2D>("PlayScreen/BG");
		}
		public override void UnloadContent() {
			base.UnloadContent();
		}
		public override void Update(GameTime gameTime) {
			
			base.Update(gameTime);
		}
		public override void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(BG, Vector2.Zero, Color.White);
		}
	}
}
