using Pathfinding_Visualizer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding_Visualizer.World
{
    public sealed class TileNode
    {
        public Vector2Int Location { get; }


        public TileNode(int x, int y)
        {
            Location = new Vector2Int(x, y);
        }
    }
}
