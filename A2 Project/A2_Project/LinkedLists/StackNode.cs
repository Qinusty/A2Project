using A2_Project.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.LinkedLists
{
    public class StackNode
    {
        /// <summary>
        /// The Item stored in the node.
        /// </summary>
        public Item Value
        {
            get;
            set;
        }
        /// <summary>
        /// The pointer to the next node.
        /// </summary>
        public StackNode Pointer;
    }    
}
