using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.LinkedLists
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T> RightNode, LeftNode;
        public T Data;
        public BinaryTreeNode(T _data)
        {
            Data = _data;
        }
    }
}
