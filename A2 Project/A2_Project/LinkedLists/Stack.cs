using A2_Project.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.LinkedLists
{       
    // A STACK FOR USE WITH ITEMS
    public class Stack
    {
        const int MaxStackSize = 20;
        public StackNode Top;
        /// <summary>
        /// Returns the amount of items in the stack.
        /// </summary>
        public int StackSize
        {
            get;
            private set;
        }
        /// <summary>
        /// Adds an item to the top of the stack
        /// </summary>
        /// <param name="itemToAdd">Item to be added</param>
        public void Push(Item itemToAdd)
        {
            StackSize += 1;
            StackNode newNode = new StackNode();
            newNode.Value = itemToAdd;
            newNode.Pointer = Top;
            Top = newNode;
        }
        /// <summary>
        /// Returns and removes the Item from the top of the stack.
        /// </summary>
        /// <returns>The item from the top of the stack.</returns>
        public Item PopReturnItem()
        {
            Item retVal;
            if (Top == null)
                return null;
            else
            {
                retVal = Top.Value;
                Pop();
            }
            
            return retVal;
        }
        /// <summary>
        /// Removes the item from the top of the stack.
        /// </summary>
        public void Pop()
        {
            if (Top != null)
            {
                Top = Top.Pointer;
            }
        }
        /// <summary>
        /// Checks if the stack is full or not based on the Maximum stack size.
        /// </summary>
        /// <returns>returns true or false.</returns>
        public bool isStackFull()
        {
            if (StackSize >= MaxStackSize)
                return true;
            else return false;
        }
    }
}
