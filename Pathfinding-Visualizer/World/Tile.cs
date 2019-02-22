using System;

namespace Pathfinding_Visualizer.World
{
    public sealed class Tile
    {
        [Flags]
        private enum TileState
        {
            Open = 1,
            Closed = 2,
            Active = 4,
            Inactive = 8
        }

        /// <summary>
        /// Resets this <see cref="Tile"/>
        /// </summary>
        public void Reset()
        {

        }
    }
}
