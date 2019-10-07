using Microsoft.Xna.Framework.Graphics;
using Pathfinding_Visualizer.Graphics;
using Pathfinding_Visualizer.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Pathfinding_Visualizer.World
{
    public sealed class Tile : IGraphic
    {
        /// <summary>
        /// The <see cref="TileType"/> of this <see cref="Tile"/>
        /// </summary>
        public TileType Type { get; set; } = TileType.Open;

        /// <summary>
        /// The rectangle containing this <see cref="Tile"/>
        /// </summary>
        public Rectangle Rectangle { get; private set; }

        // Images and bounding rectangle to draw tile
        private static Texture2D tileImage;
        private static Dictionary<TileType, Color> tileTypeColorMap = new Dictionary<TileType, Color>
        {
            { TileType.Open, Color.White },
            { TileType.Closed, Color.Black },
            { TileType.Visited, Color.Yellow },
            { TileType.Start, Color.Green },
            { TileType.Finish, Color.Red }
        };

        /// <summary>
        /// Static constructor for <see cref="Tile"/> object
        /// </summary>
        static Tile()
        {
            tileImage = Main.Singleton.Content.Load<Texture2D>("Image/White");
        }

        /// <summary>
        /// Constructor for this <see cref="Tile"/> object
        /// </summary>
        /// <param name="x">The x-coordinate of the <see cref="Tile"/></param>
        /// <param name="y">The y-coordinate of this <see cref="Tile"/></param>
        /// <param name="size">The size of this <see cref="Tile"/>, in pixels</param>
        /// <param name="buffer">The offsetting buffer of this <see cref="Tile"/>, pixels</param>
        public Tile(int x, int y, int size, int buffer)
        {
            // Setting up rectangle to draw tile
            Rectangle = new Rectangle(x * size + buffer, y * size + buffer, size, size);
        }

        /// <summary>
        /// Draws this <see cref="Tile"/>
        /// </summary>
        /// <param name="spriteBatch"><see cref="SpriteBatch"/> to draw sprites</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // Drawing appropraite tile given the tile state
            spriteBatch.Draw(tileImage, Rectangle, tileTypeColorMap[Type]);
        }

        /// <summary>
        /// Resets this <see cref="Tile"/>
        /// </summary>
        public void Reset()
        {
            // Resetting the tile type
            Type = TileType.Open;
        }
    }
}
