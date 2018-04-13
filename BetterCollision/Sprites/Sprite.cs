using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterCollision.Sprites
{
    public class Sprite
    {
        protected Texture2D _texture;

        public Vector2 Position;
        public Vector2 Velocity;
        public Color Colour = Color.White;
        public float Speed;
        public Input Input;

        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Colour);
        }

        #region Collision
        protected bool IsTouchingLeft(Sprite sprite)
        {
            return Rect.Right + Velocity.X > sprite.Rect.Left &&
                   Rect.Left < sprite.Rect.Left &&
                   Rect.Bottom > sprite.Rect.Top &&
                   Rect.Top < sprite.Rect.Bottom;
        }
        protected bool IsTouchingRight(Sprite sprite)
        {
            return Rect.Left + Velocity.X < sprite.Rect.Right &&
                   Rect.Right > sprite.Rect.Right &&
                   Rect.Bottom > sprite.Rect.Top &&
                   Rect.Top < sprite.Rect.Bottom;
        }
        protected bool IsTouchingTop(Sprite sprite)
        {
            return Rect.Bottom + Velocity.Y > sprite.Rect.Top &&
                   Rect.Top < sprite.Rect.Top &&
                   Rect.Right > sprite.Rect.Left &&
                   Rect.Left < sprite.Rect.Right;
        }
        protected bool IsTouchingBottom(Sprite sprite)
        {
            return Rect.Top + Velocity.Y < sprite.Rect.Bottom &&
                   Rect.Bottom > sprite.Rect.Bottom &&
                   Rect.Right > sprite.Rect.Left &&
                   Rect.Left < sprite.Rect.Left;
        }
        #endregion
    }
}
