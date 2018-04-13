using BetterCollision.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BetterCollision
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private List<Sprite> _sprites;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var playerTexture = Content.Load<Texture2D>("Cube");

            _sprites = new List<Sprite>()
            {
                new Player(playerTexture)
                {
                    Input = new Input()
                    {
                        Up = Keys.W,
                        Left = Keys.A,
                        Down = Keys.S,
                        Right = Keys.D,
                    },
                    Position = new Vector2(100, 100),
                    Speed = 5f
                },
                new Player(playerTexture)
                {
                    Input = new Input()
                    {
                        Up = Keys.Up,
                        Left = Keys.Left,
                        Down = Keys.Down,
                        Right = Keys.Right,
                    },
                    Position = new Vector2(100, 200),
                    Speed = 5f
                }
            };
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach(var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            foreach(var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
