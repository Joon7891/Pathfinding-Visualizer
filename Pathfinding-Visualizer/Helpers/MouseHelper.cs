using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding_Visualizer.Helpers
{
    public static class MouseHelper
    {
        /// <summary>
        /// The x-coordinate of the mouse
        /// </summary>
        public static int X => newMouse.X;

        /// <summary>
        /// The y-coordinate of the mouse
        /// </summary>
        public static int Y => newMouse.Y;

        /// <summary>
        /// The vector location of this mouse
        /// </summary>
        public static Vector2 Location => newMouse.Position.ToVector2();
        
        // Instances of old and new mouse states
        private static MouseState newMouse;
        private static MouseState oldMouse;

        /// <summary>
        /// Updates the <see cref="MouseHelper"/> class
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values</param>
        public static void Update(GameTime gameTime)
        {
            // Updating mouse states
            oldMouse = newMouse;
            newMouse = Mouse.GetState();
        }

        /// <summary>
        /// Subprogram to determine whether a left click was a new one
        /// </summary>
        /// <returns>Whether a new left click occured</returns>
        public static bool NewLeftClick() => newMouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton != ButtonState.Pressed;

        /// <summary>
        /// Subprogram to determine whether a rectangle is left clicked
        /// </summary>
        /// <param name="rectangle">The rectangle to check if it is left clicked</param>
        /// <returns>Whether the rectangle is left clicked</returns>
        public static bool IsRectangleLeftClicked(Rectangle rectangle) => NewLeftClick() && ContainsRectangle(rectangle);

        /// <summary>
        /// Subprogram to determine whether a rectangle is left pressed
        /// </summary>
        /// <param name="rectangle">The rectangle to check if it is left pressed</param>
        /// <returns>Whether the rectangle is left pressed</returns>
        public static bool IsRectangleLeftPressed(Rectangle rectangle) => newMouse.LeftButton == ButtonState.Pressed && ContainsRectangle(rectangle);

        /// <summary>
        /// Subprogram to determine if the cursor is contained within a given rectangle
        /// </summary>
        /// <param name="rectangle">The rectangle to check if the cursor contains</param>
        /// <returns>Whether the cursor is within the rectangle</returns>
        public static bool ContainsRectangle(Rectangle rectangle) => rectangle.Contains(Location);
    }
}
