using Microsoft.Xna.Framework.Graphics;

namespace Pathfinding_Visualizer.Graphics
{
    public sealed class Button : IGraphic
    {
        /// <summary>
        /// Delegate to execute when this <see cref="Button"/> is clicked
        /// </summary>
        public delegate void OnClick();
        private OnClick onClick;
        
        /// <summary>
        /// Draws this <see cref="Button"/>
        /// </summary>
        /// <param name="spriteBatch"><see cref="SpriteBatch"/> to draw sprites</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
