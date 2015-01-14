using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.Globals
{
    public static class GlobalHandler
    {
        public const double MsPerTick = 50;
        public static ContentManager content;
        public static bool WindowFocused;
        public static Screen_Management.ScreenManager ScreenManager;
        public static Camera _camera;
        public static Vector2 BufferArea;
        public static float CurrentSecondsPerCycle;
    }
}
