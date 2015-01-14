using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.LinkedLists
{
    /// <summary>
    /// A Linked list node is a variable used to store data within a linked list.
    /// </summary>
    public class MyLinkedListNode<T>
    {

        public MyLinkedListNode(T data, string priority)
        {
            Data = data;
            Priority = priority;
        }
        /// <summary>
        /// The pointer points to the next item in the list.
        /// </summary>
        public virtual MyLinkedListNode<T> Pointer
        {
            get;
            set;
        }
        /// <summary>
        /// The Data which will be stored within the Node.
        /// </summary>
        public T Data
        {
            get;
            set;
        }
        /// <summary>
        /// The priority of the Node.
        /// </summary>
        public string Priority
        {
            get;
            private set;
        }
    }
}
