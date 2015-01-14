using A2_Project.Inventory;
using A2_Project.LinkedLists;
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

    }
}
