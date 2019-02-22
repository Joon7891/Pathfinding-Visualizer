using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding_Visualizer.World
{
    public sealed class Map
    {
        private Tile[,] tiles;

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
