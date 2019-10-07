using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding_Visualizer.World
{
    /// <summary>
    /// An enum to contain the types of this <see cref="Tile"/>
    /// </summary>
    public enum TileType
    {
        /// <summary>
        /// Denotes that the tile can be visited
        /// </summary>
        Open,

        /// <summary>
        /// Denotes that the tile cannot be visited
        /// </summary>
        Closed,

        /// <summary>
        /// Denotes that the tile has been visited
        /// </summary>
        Visited,

        /// <summary>
        /// Denotes that the tile is the start
        /// </summary>
        Start,

        /// <summary>
        /// Denotes taht the tile is the finish
        /// </summary>
        Finish
    }
}
