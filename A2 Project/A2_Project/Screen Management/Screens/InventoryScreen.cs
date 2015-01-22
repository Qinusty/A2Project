using A2_Project.Extensions;
using A2_Project.InventoryObjects;
using A2_Project.LinkedLists;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.Screen_Management.Screens
{
    public class InventoryScreen : BaseScreen
    {
        private Inventory.Inventory inventory;
        private Rectangle WindowRect;
        public InventoryScreen(string screenName, Inventory.Inventory _inventory)
        {
            Name = screenName;
            inventory = _inventory;
            WindowRect = new Rectangle(30, 100, (int)Globals.GlobalHandler.BufferArea.X - 60,
                        (int)Globals.GlobalHandler.BufferArea.Y - 200);
        }
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            
            spriteBatch.Begin();

                spriteBatch.Draw(new SolidColorTexture(Color.WhiteSmoke),
                    WindowRect, Color.WhiteSmoke);

            foreach (InventorySlot invSlot in inventory.InventorySlots)
            {
                invSlot.Draw(spriteBatch, new Rectangle(WindowRect.X + 10, WindowRect.Y + 10, 64, 64));
            }

            spriteBatch.End();
            base.Draw(spriteBatch);
        }
    }
}
