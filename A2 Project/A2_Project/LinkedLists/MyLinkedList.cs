using A2_Project.Inventory;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.LinkedLists
{
    public class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Start
        {
            get;
            protected set;
        }
        public MyLinkedListNode<T> End
        {
            get;
            protected set;
        }
        /// <summary>
        /// Adds an item to list where its position is defined by its priority.
        /// </summary>
        /// <param name="ItemToAdd">Node storing the item to add and the priority of the item.</param>
        public virtual void AddToList(MyLinkedListNode<T> ItemToAdd)
        {
            MyLinkedListNode<T> CurrentItem, PreviousItem;
            PreviousItem = Start;
            CurrentItem = Start;
            if (Start == null)
            {
                Start = ItemToAdd;
                End = ItemToAdd;
            }
            else if (string.Compare(ItemToAdd.Priority, Start.Priority) < 0)
            {
                ItemToAdd.Pointer = Start;
                Start = ItemToAdd;
            }
            else if (string.Compare(ItemToAdd.Priority, End.Priority) > 0)
            {
                End.Pointer = ItemToAdd;
                End = ItemToAdd;
            }
            else
            {
                do
                {
                    PreviousItem = CurrentItem;
                    CurrentItem = CurrentItem.Pointer;
                } while (string.Compare(CurrentItem.Priority, ItemToAdd.Priority) < 0 && CurrentItem != End);
                PreviousItem.Pointer = ItemToAdd;
                ItemToAdd.Pointer = CurrentItem;
            }
        }        
    }
}
