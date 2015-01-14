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
        public int StackSize
        {
            get;
            private set;
        }

        public void Push(Item itemToAdd)
        {
            StackSize += 1;
            StackNode newNode = new StackNode();
            newNode.Value = itemToAdd;
            newNode.Pointer = Top;
            Top = newNode;
        }

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
        public void Pop()
        {
            if (Top != null)
            {
                Top = Top.Pointer;
            }
        }
        public bool isStackFull()
        {
            if (StackSize >= MaxStackSize)
                return true;
            else return false;
        }
    }
}
