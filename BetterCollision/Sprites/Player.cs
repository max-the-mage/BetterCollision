using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BetterCollision.Sprites
{
    public class Player : Sprite
    {
        public Player(Texture2D texture) : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            foreach(var sprite in sprites)
            {
                if (sprite == this)
                    continue;

                if (Velocity.X > 0 && IsTouchingLeft(sprite) ||
                    Velocity.X < 0 && IsTouchingRight(sprite))
                    Velocity.X = 0;

                if (Velocity.Y > 0 && IsTouchingTop(sprite) ||
                    Velocity.Y < 0 && IsTouchingBottom(sprite))
                    Velocity.Y = 0;
            }

            Position += Velocity;

            Velocity = Vector2.Zero;
        }

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = Speed;

            if (Keyboard.GetState().IsKeyDown(Input.Up))
                Velocity.Y = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
                Velocity.Y = Speed;
        }
    }
}
