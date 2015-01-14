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
            do
            {
                try
                {
                    int index = findIndex(ItemToAdd);
                    if (!InventorySlots[index].ItemStack.isStackFull())
                    {
                        InventorySlots[index].ItemStack.Push(ItemToAdd);
                        return;
                    }

                    // Break the do loop
                }
                catch (Exception)
                {
                    Console.WriteLine("Item not found in inventory.");
                    InventorySlots.Add(new InventorySlot(ItemToAdd));
                    Console.WriteLine("New stack created in for item in inventory.");
                }
            } while (true);

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
