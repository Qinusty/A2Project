using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.LinkedLists
{
    public delegate SortStatus ComesBefore<T>(T first, T second);

    public class BinaryTree<T>
    {
        public ComesBefore<T> Comparer;
        public BinaryTreeNode<T> RootNode;

        public BinaryTree(ComesBefore<T> comparer)
        {
            Comparer = comparer;
        }
        public void Insert(T _data)
        {
            // ALL WRONG, FORGET RECURSION, RECURSION, RECURSION....
        }
        private BinaryTreeNode<T> FindInsertionPoint(BinaryTreeNode<T> cNode, T _data)
        {
            // Base Case
            if (cNode == null)
                return new BinaryTreeNode<T>(_data);
            else if (Comparer.Invoke(cNode.Data, _data) == SortStatus.Before || Comparer.Invoke(cNode.Data, _data) == SortStatus.Equal)
                return FindInsertionPoint(cNode.LeftNode, _data);
            else return FindInsertionPoint(cNode.RightNode, _data);
        } // FINISH BASIC ITEM/INVENTORY AND TEST THE BINARY TREE INSERT ALGORITHM, IT MAY NOT WORK.
    }

    public enum SortStatus
    {
        Before,
        Equal,
        After
    }
}
