namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left = null, IAbstractBinaryTree<T> right = null)
        {
            this.Value = element;
            this.LeftChild = left;
            this.RightChild = right;

        }

        public T Value { get; set; }

        public IAbstractBinaryTree<T> LeftChild { get; set; }

        public IAbstractBinaryTree<T> RightChild { get; set; }

        public string AsIndentedPreOrder(int indent)
        {
            return DFSIndentedPreOrder(this, indent);

        }

        private static string DFSIndentedPreOrder(IAbstractBinaryTree<T> tree, int indent)
        {

            string result = $"{new String(' ', indent)}{tree.Value}\r\n";
            if (tree.LeftChild != null)
            {
                result += $"{DFSIndentedPreOrder(tree.LeftChild, indent + 2)}";


            }

            if (tree.RightChild != null)
            {
                result += $"{DFSIndentedPreOrder(tree.RightChild, indent + 2)}";


            }

            return result;

        }

        public void ForEachInOrder(Action<T> action)
        {
            DFSInOrder(this, null, action);
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            var nodes = new List<IAbstractBinaryTree<T>>();
            DFSInOrder(this, nodes);
            return nodes;
        }

        private void DFSInOrder(IAbstractBinaryTree<T> tree, List<IAbstractBinaryTree<T>> nodes = null, Action<T> action = null)
        {

            if (tree.LeftChild != null)
            {

                DFSInOrder(tree.LeftChild, nodes, action);

            }
            if (nodes != null)
                nodes.Add(tree);
            else
                action(tree.Value);
            if (tree.RightChild != null)
            {

                DFSInOrder(tree.RightChild, nodes, action);

            }
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            var nodes = new List<IAbstractBinaryTree<T>>();
            DFSPostOrder(nodes, this);
            return nodes;
        }

        private void DFSPostOrder(List<IAbstractBinaryTree<T>> nodes, IAbstractBinaryTree<T> tree)
        {

            if (tree.LeftChild != null)
            {

                DFSPostOrder(nodes, tree.LeftChild);

            }

            if (tree.RightChild != null)
            {

                DFSPostOrder(nodes, tree.RightChild);

            }
            nodes.Add(tree);
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            var nodes = new List<IAbstractBinaryTree<T>>();
            DFSPreOrder(nodes, this);
            return nodes;
        }

        private void DFSPreOrder(List<IAbstractBinaryTree<T>> nodes, IAbstractBinaryTree<T> tree)
        {
            nodes.Add(tree);
            if (tree.LeftChild != null)
            {

                DFSPreOrder(nodes, tree.LeftChild);

            }

            if (tree.RightChild != null)
            {

                DFSPreOrder(nodes, tree.RightChild);

            }
        }
    }
}
