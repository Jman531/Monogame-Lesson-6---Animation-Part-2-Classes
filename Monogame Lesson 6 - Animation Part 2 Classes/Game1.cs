using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_Lesson_6___Animation_Part_2_Classes
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        bool justUpdatedScreen = false;

        Tribble tribble1, tribble2, tribble3, tribble4;

        MouseState mouseState;

        Rectangle window;

        Texture2D greyTribbleTexture, brownTribbleTexture, creamTribbleTexture, orangeTribbleTexture, tribbleIntroTexture;

        SoundEffect tribbleCoo;
        SpriteFont instructionFont;

        Random generator = new Random();

        enum Screen
        {
            Intro,
            TribbleYard
        }

        Screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen = Screen.Intro;

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            base.Initialize();
            tribble1 = new Tribble(greyTribbleTexture, new Rectangle(generator.Next(0, 701), generator.Next(0, 501), 100, 100), new Vector2(2, 2));
            tribble2 = new Tribble(brownTribbleTexture, new Rectangle(generator.Next(0, 701), generator.Next(0, 501), 100, 100), new Vector2(generator.Next(-10, 11), 0));
            tribble3 = new Tribble(creamTribbleTexture, new Rectangle(generator.Next(0, 701), generator.Next(0, 501), 100, 100), new Vector2(0, generator.Next(-10, 11)));
            tribble4 = new Tribble(orangeTribbleTexture, new Rectangle(generator.Next(0, 701), generator.Next(0, 501), 100, 100), new Vector2(generator.Next(-10, 11), generator.Next(-10, 11)));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            greyTribbleTexture = Content.Load<Texture2D>("tribbleGrey");
            brownTribbleTexture = Content.Load<Texture2D>("tribbleBrown");
            creamTribbleTexture = Content.Load<Texture2D>("tribbleCream");
            orangeTribbleTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleIntroTexture = Content.Load<Texture2D>("tribble_intro");
            instructionFont = Content.Load<SpriteFont>("instruction");
            tribbleCoo = Content.Load<SoundEffect>("tribble_coo");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screen = Screen.TribbleYard;
                    justUpdatedScreen = true;
                }
            }
            else if (screen == Screen.TribbleYard)
            {
                tribble1.Move(window);
                tribble2.Move(window);
                tribble3.Move(window);
                tribble4.Move(window);

                if (mouseState.LeftButton != ButtonState.Pressed)
                    justUpdatedScreen = false;

                if (mouseState.LeftButton == ButtonState.Pressed && !justUpdatedScreen)
                    this.Exit();
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(tribbleIntroTexture, new Rectangle(0, 0, 800, 600), Color.White);
                _spriteBatch.DrawString(instructionFont, "Click to start.", new Vector2(0, 0), Color.Black);
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(tribble1.Texture, tribble1.Bounds, Color.White);
                _spriteBatch.Draw(tribble2.Texture, tribble2.Bounds, Color.White);
                _spriteBatch.Draw(tribble3.Texture, tribble3.Bounds, Color.White);
                _spriteBatch.Draw(tribble4.Texture, tribble4.Bounds, Color.White);
                _spriteBatch.DrawString(instructionFont, "Click to end.", new Vector2(0, 0), Color.Black);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
