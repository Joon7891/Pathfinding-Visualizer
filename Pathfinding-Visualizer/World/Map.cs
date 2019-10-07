using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pathfinding_Visualizer.Core;
using Pathfinding_Visualizer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pathfinding_Visualizer.World;

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
        private Vector2Int start;
        private Vector2Int finish;

        // Search related variables
        private float deltaTime = -0.1f;
        private Queue<Vector2Int> toVisit = new Queue<Vector2Int>();
        private static Vector2Int[] directions =
        {
            Vector2Int.UnitX,
            Vector2Int.UnitY,
            -Vector2Int.UnitX,
            -Vector2Int.UnitY
        };

        /// <summary>
        /// Constructor for this <see cref="Map"/>
        /// </summary>
        /// <param name="size">The size of the <see cref="Map"/>, in <see cref="Tile"/></param>
        public Map(int size)
        {
            // Assiging size and resizing the map
            this.size = size;
            Resize();

            // Assigning start and finish
            start = new Vector2Int(0, 0);
            tiles[0, 0].Type = TileType.Start;
            finish = new Vector2Int(size - 1, size - 1);
            tiles[size - 1, size - 1].Type = TileType.Finish;
        }

        /// <summary>
        /// Update subprogram for this <see cref="Map"/>
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values</param>
        public void Update(GameTime gameTime)
        {
            // Run search if appropriate, otherwise update map tiles
            if (Main.Singleton.SearchStatus)
            {
                RunSearch(gameTime);
            }
            else
            {
                // Can be done in O(1) with some math functions
                for (int i = 0; i < Size; ++i)
                {
                    for (int j = 0; j < Size; ++j)
                    {
                        if (MouseHelper.IsRectangleLeftPressed(tiles[i, j].Rectangle))
                        {
                            if (KeyboardHelper.IsKeyDown(Keys.A)) tiles[i, j].Type = TileType.Open;
                            else if (KeyboardHelper.IsKeyDown(Keys.W)) tiles[i, j].Type = TileType.Closed;
                            else if (KeyboardHelper.IsKeyDown(Keys.S)) AssignStart(i, j);
                            else if (KeyboardHelper.IsKeyDown(Keys.E)) AssignFinish(i, j);
                        }
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
        /// Subprogram to run the pathfinding search from start to finish
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values</param>
        private void RunSearch(GameTime gameTime)
        {
            // New to visit queue
            Queue<Vector2Int> newToVisit = new Queue<Vector2Int>();
            
            // Updating time and entering search if appropriate time has been elasped
            deltaTime += gameTime.ElapsedGameTime.Milliseconds / 1000.0f;
            if (deltaTime >= Main.Singleton.SearchTime)
            {
                deltaTime -= Main.Singleton.SearchTime;

                // Looping through all tiles to visit
                while (toVisit.Count > 0)
                {
                    Vector2Int curLocation = toVisit.Dequeue();
                    tiles[curLocation.X, curLocation.Y].Type = TileType.Visited;

                    // Adding adjcaent tiles if appropriate
                    foreach (Vector2Int direction in directions)
                    {
                        Vector2Int newLocation = curLocation + direction;
                        if (ValidSearchTile(newLocation)) newToVisit.Enqueue(newLocation);
                    }
                }
            }

            // Moving elements of new queue into old queue
            while (newToVisit.Count > 0) toVisit.Enqueue(newToVisit.Dequeue());
        }

        /// <summary>
        /// Subprogram to determine whether a tile location is valid as a search tile
        /// </summary>
        /// <param name="location">The location to check if is valid</param>
        /// <returns>Whether the tile is a valid tile</returns>
        private bool ValidSearchTile(Vector2Int location)
        {
            // Returning if the coordinate is an appropriate type
            if (0 <= location.X && location.X < Size &&
                0 <= location.Y && location.Y < Size)
            {
                return tiles[location.X, location.Y].Type == TileType.Finish ||
                    tiles[location.X, location.Y].Type == TileType.Open;
            }

            // Otherwise return false
            return false;
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
            // Loops through all tiles and resets them
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    tiles[i, j].Reset();
                }
            }
        }

        /// <summary>
        /// Subprogram to assign the map's start
        /// </summary>
        /// <param name="x">The x-coordinate of the new start</param>
        /// <param name="y">The y-coordinate of the new start</param>
        private void AssignStart(int x, int y)
        {
            // Assiging new start
            tiles[start.X, start.Y].Type = TileType.Open;
            tiles[x, y].Type = TileType.Start;
            start.X = x;
            start.Y = y;
        }

        /// <summary>
        /// Syubprogram to assign the map's finish
        /// </summary>
        /// <param name="x">The x-coordinate of the new finish</param>
        /// <param name="y">The y-coordinate of the new finish</param>
        private void AssignFinish(int x, int y)
        {
            // Assigning new end
            tiles[finish.X, finish.Y].Type = TileType.Open;
            tiles[x, y].Type = TileType.Finish;
            finish.X = x;
            finish.Y = y;
        }
    }
}
