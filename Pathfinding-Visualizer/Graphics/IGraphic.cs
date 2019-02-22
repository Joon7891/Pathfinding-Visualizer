using Microsoft.Xna.Framework.Graphics;

namespace Pathfinding_Visualizer.Graphics
{
    /// <summary>
    /// Interface to contain definitions for a graphical object
    /// </summary>
    public interface IGraphic
    {
        /// <summary>
        /// Draws this <see cref="IGraphic"/>
        /// </summary>
        /// <param name="spriteBatch"><see cref="SpriteBatch"/> to draw sprites</param>
        void Draw(SpriteBatch spriteBatch);
    }
}
