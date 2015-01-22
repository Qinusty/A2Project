using A2_Project.Globals;
using A2_Project.Inventory;
using A2_Project.LinkedLists;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.InventoryObjects
{
    public class InventorySlot
    {
        public string ItemName;
        public Stack ItemStack;

        public InventorySlot(Item Item)
        {
            ItemName = Item.ItemName;
            ItemStack = new Stack();
        }
        public bool isEmpty
        {
            get
            {
                return ItemStack.StackSize == 0;
            }
        }
        public void Draw(SpriteBatch sb, Rectangle DrawRect)
        {
            sb.Draw(ItemStack.Top.Value.Image, DrawRect, Color.White);
            sb.DrawString(Fonts.InventorySlotFont, ItemStack.StackSize.ToString(),
                new Vector2(DrawRect.Right, DrawRect.Bottom) - Fonts.InventorySlotFont.MeasureString(ItemStack.StackSize.ToString()),
                Color.Red);
        }

    }
}
