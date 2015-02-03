using A2_Project.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.Extensions
{
    public static class InputHelper
    {
        private static KeyboardState keyboardState, lastKeyboardState;
        private static MouseState mouseState, lastMouseState;
        private static Vector2 MousePosition
        {
            get
            {
                return new Vector2(mouseState.X, mouseState.Y);
            }
        }
        public static void Update()
        {
            lastKeyboardState = keyboardState;
            lastMouseState = mouseState;

            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
        }
        #region "Public Functions"
        public static bool isKeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }
        public static bool isKeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key);
        }
        public static bool isLMBDown()
        {
            return mouseState.LeftButton == ButtonState.Pressed;
        }
        public static bool isRMBDown()
        {
            return mouseState.RightButton == ButtonState.Pressed;
        }
        public static bool isLMBPressed()
        {
            return mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released;
        }
        public static bool isRMBPressed()
        {
            return mouseState.RightButton == ButtonState.Pressed && lastMouseState.RightButton == ButtonState.Released;
        }
        #endregion
    }
}
