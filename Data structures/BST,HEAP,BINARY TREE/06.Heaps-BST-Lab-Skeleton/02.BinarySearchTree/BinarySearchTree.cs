namespace _02.BinarySearchTree
{
    using _04.BinarySearchTree;
    using System;
    using System.Xml;
    using System.Xml.Linq;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {

        public BinarySearchTree()
        {


        }
        private BinarySearchTree(Node<T> node)
        {
            this.PreOrderCopy(node);
        }

        private void PreOrderCopy(Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.LeftChild);
            this.PreOrderCopy(node.RightChild);
        }

        public Node<T> Root { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }




        public bool Contains(T element)
        {

            return ContainsElement(this.Root, element);

        }

        private bool ContainsElement(Node<T> root, T element)
        {
            if (root == null)
            {
                return false;

            }
            if (element.CompareTo(root.Value) > 0)
            {

                return ContainsElement(root.RightChild, element);

            }
            else if (element.CompareTo(root.Value) < 0)
            {
                return ContainsElement(root.LeftChild, element);
            }

            return true;
        }

        public void EachInOrder(Action<T> action)
        {
            DFSInOrder(this.Root, action);
        }

        private void DFSInOrder(Node<T> tree, Action<T> action)
        {
            if (tree.LeftChild != null)
            {
                DFSInOrder(tree.LeftChild, action);

            }
            action(tree.Value);
            if (tree.RightChild != null)
            {
                DFSInOrder(tree.RightChild, action);

            }


        }

        public void Insert(T element)
        {
            if (this.Root == null)
            {
                this.Root = new Node<T>(element);
                return;
            }
            InsertElement(element, this.Root);
        }

        private void InsertElement(T element, Node<T> root)
        {

            if (element.CompareTo(root.Value) > 0)
            {
                if (root.RightChild == null)
                {
                    var el = new Node<T>(element);
                    root.RightChild = el;
                    return;
                }
                InsertElement(element, root.RightChild);

            }
            else if (element.CompareTo(root.Value) < 0)
            {
                if (root.LeftChild == null)
                {
                    var el = new Node<T>(element);
                    root.LeftChild = el;
                    return;
                }

                InsertElement(element, root.LeftChild);
            }
        }

        public IBinarySearchTree<T> Search(T element)
        {

            return FindElement(this.Root, element);
        }

        private IBinarySearchTree<T> FindElement(Node<T> root, T element)
        {
            if (root == null)
            {
                return null;

            }
            if (root.Value.CompareTo(element) == 0)
            {
                return new BinarySearchTree<T>(root);

            }
            if (element.CompareTo(root.Value) > 0)
            {

                return FindElement(root.RightChild, element);

            }
            else if (element.CompareTo(root.Value) < 0)
            {
                return FindElement(root.LeftChild, element);
            }
            return null;

        }
    }
}
