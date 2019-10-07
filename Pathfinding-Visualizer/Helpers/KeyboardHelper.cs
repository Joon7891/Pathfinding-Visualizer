using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding_Visualizer.Helpers
{
    public static class KeyboardHelper
    {
        private static KeyboardState newKeyboard;
        private static KeyboardState oldKeyboard;

        /// <summary>
        /// Updates the <see cref="KeyboardHelper"/> class 
        /// </summary>
        /// <param name="gameTime"></param>
        public static void Update(GameTime gameTime)
        {
            // Updating keyboard states
            oldKeyboard = newKeyboard;
            newKeyboard = Keyboard.GetState();
        }

        /// <summary>
        /// Subprogram to determine if a key is pressed down
        /// </summary>
        /// <param name="key">The key to check if is down</param>
        /// <returns>Whether the key is down</returns>
        public static bool IsKeyDown(Keys key) => newKeyboard.IsKeyDown(key);

        /// <summary>
        /// Subprogram to determine if the current key is a new keystroke
        /// </summary>
        /// <param name="key">The key to check if it is a new keystroke</param>
        /// <returns>Whether the key stroke was a new keystroke</returns>
        public static bool NewKeystroke(Keys key) => newKeyboard.IsKeyDown(key) && oldKeyboard.IsKeyUp(key);
    }
}
