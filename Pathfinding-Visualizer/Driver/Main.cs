using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pathfinding_Visualizer.Utility;
using Pathfinding_Visualizer.World;

namespace Pathfinding_Visualizer.Driver
{
    /// <summary>
    /// The driver class of this program
    /// </summary>
    public class Main : Game
    {
        /// <summary>
        /// Static singleton instance of <see cref="Main"/>
        /// </summary>
        public static Main Singleton { get; private set; }

        /// <summary>
        /// <see cref="ContentManager"/> for <see cref="Main"/>
        /// </summary>
        public new ContentManager Content { get; private set; }

        // Graphics handling object
        private SpriteBatch spriteBatch;
        private GraphicsDeviceManager graphics;

        // Screen width and height
        public const int WIDTH = 960;
        public const int HEIGHT = 640;

        // Instance of the game map
        private Map map;

        /// <summary>
        /// Constructor for this <see cref="Main"/>
        /// </summary>
        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content = base.Content;
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
            // Setting up graphic frame
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = HEIGHT;
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Creating spritebatch and setting up singleton
            Singleton = this;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Creating new map
            map = new Map(10);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            // Updating various utility
            MouseHelper.Update(gameTime);

            // Updating map
            map.Update(gameTime);

            // Updating parent game
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Beginning spriteBatch
            spriteBatch.Begin();

            // Drawing map
            map.Draw(spriteBatch);

            // Drawing base game and ending spriteBatch
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
