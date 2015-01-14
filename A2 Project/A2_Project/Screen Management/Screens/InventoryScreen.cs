using A2_Project.Extensions;
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
        public InventoryScreen(string screenName, Inventory.Inventory _inventory)
        {
            Name = screenName;
            inventory = _inventory;
        }
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            
            spriteBatch.Begin();
            for (int i = 0; i < inventory.InventorySlots.Count; i++)
            {
                
            }
                spriteBatch.Draw(new SolidColorTexture(Color.WhiteSmoke),
                    new Rectangle(30, 100, (int)Globals.GlobalHandler.BufferArea.X - 60,
                        (int)Globals.GlobalHandler.BufferArea.Y - 200), Color.WhiteSmoke);

            spriteBatch.End();
            base.Draw(spriteBatch);
        }
    }
}
