using A2_Project.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.LinkedLists
{
    public class StackNode
    {
        public Item Value
        {
            get;
            set;
        }
        public StackNode Pointer;
    }    
}
