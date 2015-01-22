using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A2_Project.LinkedLists;
using A2_Project.InventoryObjects;

namespace A2_Project.Inventory
{

    public class Inventory
    {
        public List<InventorySlot> InventorySlots;
        private int SlotsFilled;
        private int TotalSlots;
        public string InventoryName;
        public Inventory(string InvName, int maxSize)
        {
            InventoryName = InvName;
            TotalSlots = maxSize;
            SlotsFilled = 0;
            InventorySlots = new List<InventorySlot>(maxSize);
        }
        public void AddToInventory(Item ItemToAdd)
        {
            int index = findIndex(ItemToAdd);
            if (index == -1)
            {
                InventorySlots.Add(new InventorySlot(ItemToAdd));
                AddToInventory(ItemToAdd);
            }
            else
            {
                if (!InventorySlots[index].ItemStack.isStackFull())
                    InventorySlots[index].ItemStack.Push(ItemToAdd);
            }
        }
        /// <summary>
        /// returns -1 if not found.
        /// </summary>
        /// <param name="itemToFind"></param>
        /// <returns></returns>
        private int findIndex(Item itemToFind)
        {
            for (int i = 0; i < InventorySlots.Count; i++)
            {
                if (InventorySlots[i].ItemName == itemToFind.ItemName)
                {
                    if (!InventorySlots[i].ItemStack.isStackFull())
                        return i;
                }

            }
            return -1;
        }
        public void DisplaySingleInventory()
        {

        }
    }
}
