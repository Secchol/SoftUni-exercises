using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BinarySearchTree
{
    public class Node<T>
    {


        public Node(T value, Node<T> LeftChild = null, Node<T> RightChild = null)
        {
            this.Value = value;
            this.LeftChild = LeftChild;
            this.RightChild = RightChild;


        }
        public T Value { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }


    }
}
