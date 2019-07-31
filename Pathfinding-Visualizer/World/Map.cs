using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pathfinding_Visualizer.Driver;
using Pathfinding_Visualizer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pathfinding_Visualizer.World.Tile;

namespace Pathfinding_Visualizer.World
{
    public sealed class Map
    {
        /// <summary>
        /// The size of this <see cref="Map"/>, in <see cref="Tile"/>s
        /// </summary>
        public int Size
        {
            get => size;
            set
            {
                size = value;
                Resize();
            }
        }
        private int size;

        // Grid related variables
        private Tile[,] tiles;

        /// <summary>
        /// Constructor for this <see cref="Map"/>
        /// </summary>
        /// <param name="size">The size of the <see cref="Map"/>, in <see cref="Tile"/></param>
        public Map(int size)
        {
            // Assiging size and resizing the map
            this.size = size;
            Resize();
        }

        /// <summary>
        /// Update subprogram for this <see cref="Map"/>
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values</param>
        public void Update(GameTime gameTime)
        {
            // Can be done in O(1) with some math functions
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    if (MouseHelper.IsRectangleLeftClicked(tiles[i, j].Rectangle))
                    {
                        tiles[i, j].FlipState();
                    }
                }
            }
        }

        /// <summary>
        /// Draw subprogram for this <see cref="Map"/>
        /// </summary>
        /// <param name="spriteBatch"><see cref="SpriteBatch"/> to draw sprites</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // Drawing all tiles
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    tiles[i, j].Draw(spriteBatch);
                }
            }
        }

        /// <summary>
        /// Resizes this <see cref="Map"/>
        /// </summary>
        private void Resize()
        {
            // Recalculating tile properties
            int size = Main.HEIGHT / Size;
            int buffer = (Main.HEIGHT - size * Size) / 2;

            // Reconstructing map given new tile properties
            tiles = new Tile[Size, Size];
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    tiles[i, j] = new Tile(i, j, size, buffer);
                }
            }
        }

        /// <summary>
        /// Resets this <see cref="Map"/>
        /// </summary>
        public void Reset()
        {
            for (int i = 0; i < tiles.GetLength(0); ++i)
            {
                for (int j = 0; j < tiles.GetLength(1); ++j)
                {
                    tiles[i, j].Reset();
                }
            }
        }
    }
}
