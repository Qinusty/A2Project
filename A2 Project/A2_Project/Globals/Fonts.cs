using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace A2_Project.Globals
{
    public static class Fonts
    {
        public static SpriteFont MenuOptionFont, NarrativeFont, DebugFont, InventorySlotFont;

        public static void Load(ContentManager content)
        {
            InventorySlotFont = content.Load<SpriteFont>("sFonts/InventorySlotText");
            DebugFont = content.Load<SpriteFont>("sFonts/DebugFont");
        }
    }
}
