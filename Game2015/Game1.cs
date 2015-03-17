#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Game2015
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        //Game
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D rectangle;
        private SpriteFont font;

        //Game attributes
        private int score = 0;

        //Character attributes
        private float angle = 0;
        private AnimatedSprite animatedSprite;
        Texture2D TestWalk;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //rectangle = Content.Load<Texture2D>("Pictures/Rectangle");
           font = Content.Load<SpriteFont>("Fonts/Score");
            TestWalk = Content.Load<Texture2D>("Pictures/SmileyWalk");
            animatedSprite = new AnimatedSprite(TestWalk, 4, 4);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            angle += 0.01f;
            animatedSprite.Update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // spriteBatch.Begin();

            //Used for rotation
            // Vector2 location = new Vector2(400, 240);
            // Rectangle sourceRectangle = new Rectangle(0, 0, rectangle.Width, rectangle.Height);
            // Vector2 origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);

            // spriteBatch.DrawString(font, "Score" + "  " + score, new Vector2(0, 0), Color.Black);
            // spriteBatch.Draw(rectangle, location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);

            //spriteBatch.End();

            animatedSprite.Draw(spriteBatch, new Vector2(400, 200));

            base.Draw(gameTime);
        }
    }
}
