using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Lesson_2_Prgramming_Chalenge
{

    //Wilson

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tileTexture;

        Rectangle tile;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 640;
            _graphics.ApplyChanges();

            tile = new Rectangle(0, 0, 80, 80);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            tileTexture = Content.Load<Texture2D>("rectangle");
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            
            for (int i = 0; i < 640; i += tile.Width* 2)
            {
                for (int j = 0; j < 640; j += tile.Height * 2)
                {
                    _spriteBatch.Draw(tileTexture, tile, Color.White);
                    
                    tile = new Rectangle(i + tile.Width, j + tile.Height, 80, 80); //Sets the tile location to the row underneath and off to the side
                    _spriteBatch.Draw(tileTexture, tile, Color.White);
                    
                    tile = new Rectangle(i + tile.Width, j, 80, 80); //Sets the tile location to where the black tiles should be
                    _spriteBatch.Draw(tileTexture, tile, Color.Black);

                    tile = new Rectangle(i, j + tile.Height, 80, 80); //Sets the tile location to the row underneath
                    _spriteBatch.Draw(tileTexture, tile, Color.Black);

                    tile = new Rectangle(i, j, 80, 80); //Resets tile location to i and j
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}