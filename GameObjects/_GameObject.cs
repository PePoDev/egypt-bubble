using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GP_Midterm_BubblePuzzle {
	public class _GameObject : ICloneable {
		protected Texture2D _texture;
		public Vector2 Position;
		public float Rotation;
		public Vector2 Scale;
		public Vector2 Velocity;
		public string Name;
		public bool IsActive;

		public Rectangle Rectangle {
			get {
				return new Rectangle((int)Position.X, (int)Position.Y, Viewport.Width, Viewport.Height);
			}
		}

		public Rectangle Viewport;

		public _GameObject() {
			Position = Vector2.Zero;
			Scale = Vector2.One;
			Rotation = 0f;
			IsActive = true;
		}

		public _GameObject(Texture2D texture) {
			_texture = texture;
			Position = Vector2.Zero;
			Scale = Vector2.One;
			Rotation = 0f;
			IsActive = true;
		}

		public virtual void Update(GameTime gameTime, List<_GameObject> _GameObjects) {

		}

		public virtual void Draw(SpriteBatch spriteBatch) {
		}

		public virtual void Reset() {

		}

		public object Clone() {
			return MemberwiseClone();
		}

		#region Collision
		protected bool IsTouching(_GameObject g) {
			return IsTouchingLeft(g) ||
				IsTouchingTop(g) ||
				IsTouchingRight(g) ||
				IsTouchingBottom(g);
		}

		protected bool IsTouchingLeft(_GameObject g) {
			return this.Rectangle.Right > g.Rectangle.Left &&
					this.Rectangle.Left < g.Rectangle.Left &&
					this.Rectangle.Bottom > g.Rectangle.Top &&
					this.Rectangle.Top < g.Rectangle.Bottom;
		}

		protected bool IsTouchingRight(_GameObject g) {
			return this.Rectangle.Right > g.Rectangle.Right &&
					this.Rectangle.Left < g.Rectangle.Right &&
					this.Rectangle.Bottom > g.Rectangle.Top &&
					this.Rectangle.Top < g.Rectangle.Bottom;
		}

		protected bool IsTouchingTop(_GameObject g) {
			return this.Rectangle.Right > g.Rectangle.Left &&
					this.Rectangle.Left < g.Rectangle.Right &&
					this.Rectangle.Bottom > g.Rectangle.Top &&
					this.Rectangle.Top < g.Rectangle.Top;
		}

		protected bool IsTouchingBottom(_GameObject g) {
			return this.Rectangle.Right > g.Rectangle.Left &&
					this.Rectangle.Left < g.Rectangle.Right &&
					this.Rectangle.Bottom > g.Rectangle.Bottom &&
					this.Rectangle.Top < g.Rectangle.Bottom;
		}
		#endregion
	}
}
