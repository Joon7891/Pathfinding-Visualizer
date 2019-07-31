using Microsoft.Xna.Framework.Graphics;
using Pathfinding_Visualizer.Graphics;
using Pathfinding_Visualizer.Driver;
using Microsoft.Xna.Framework;
using System;

namespace Pathfinding_Visualizer.World
{
    public sealed class Tile : IGraphic
    {
        /// <summary>
        /// An enum to contain the states of this <see cref="Tile"/>
        /// </summary>
        [Flags]
        public enum TileState
        {
            /// <summary>
            /// Denotes that the tile can be visited
            /// </summary>
            Open = 1,

            /// <summary>
            /// Denotes that the tile cannot be visited
            /// </summary>
            Closed = 2,

            /// <summary>
            /// Denotes that the tile has been visited in the path search
            /// </summary>
            Active = 4,

            /// <summary>
            /// Denotes that the tile has not been visited in the paths search
            /// </summary>
            Inactive = 8
        }

        /// <summary>
        /// The <see cref="TileState"/> of this <see cref="Tile"/>
        /// </summary>
        public TileState State { get; private set; } = TileState.Open | TileState.Inactive;

        /// <summary>
        /// The rectangle containing this <see cref="Tile"/>
        /// </summary>
        public Rectangle Rectangle { get; private set; }

        // Images and bounding rectangle to draw tile
        private static Texture2D tileImage;

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
            if (State.HasFlag(TileState.Open))
            {
                spriteBatch.Draw(tileImage, Rectangle, State.HasFlag(TileState.Active) 
                    ? Color.Green : Color.White);
            }
            else
            {
                spriteBatch.Draw(tileImage, Rectangle, Color.Black);
            }
        }

        /// <summary>
        /// Subprogram to flip the state of this <see cref="Tile"/>
        /// </summary>
        public void FlipState()
        {
            // Flipes the open/closed state of the tile
            if (State.HasFlag(TileState.Open)) State++;
            else State--;
        }

        /// <summary>
        /// Resets this <see cref="Tile"/>
        /// </summary>
        public void Reset()
        {
            State = TileState.Open | TileState.Inactive;
        }
    }
}
