using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using A2_Project.Globals;
using A2_Project.Entities;
using A2_Project.Extensions;
using A2_Project.StarBackground;
using System.Windows.Forms;

namespace A2_Project
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const string version = "v0.0.1";
        private double FPSTimer = 0;
        private int FPSCount;
        private int displayFPS;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            GlobalHandler.content = Content;
            GlobalHandler.content.RootDirectory = "Content";
            GlobalHandler.ScreenManager = new Screen_Management.ScreenManager();
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
            
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;

            graphics.ApplyChanges();
            GlobalHandler.BufferArea = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            IsMouseVisible = true;
            Window.AllowUserResizing = false;
            GlobalHandler._camera = new Camera(GraphicsDevice.Viewport);
            SolidColorTexture.initialise(GraphicsDevice);
            GlobalHandler.ScreenManager = new Screen_Management.ScreenManager();
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
            Textures.Load(GlobalHandler.content, GraphicsDevice);
            Fonts.Load(GlobalHandler.content);
            
            // ADD DEFAULT SCREENS HERE
            Globals.GlobalHandler.ScreenManager.AddScreen(new Screen_Management.Screens.GameScreen("Game Screen"));

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            GlobalHandler.WindowFocused = this.IsActive;
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                this.Exit();
            Globals.GlobalHandler.ScreenManager.Update(gameTime);
            Globals.GlobalHandler.CurrentSecondsPerCycle = (float)gameTime.ElapsedGameTime.TotalSeconds;
            InputHelper.Update();
            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // DEBUG
            FPSTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            FPSCount += 1;
            if (FPSTimer >= 1000)
            {
                FPSTimer = 0;
                displayFPS = FPSCount;
                FPSCount = 0;
            }
            spriteBatch.Begin();
            spriteBatch.DrawString(Fonts.DebugFont, "FPS: " + displayFPS, new Vector2(10, 10), Color.Red);
            spriteBatch.End();
            Globals.GlobalHandler.ScreenManager.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
