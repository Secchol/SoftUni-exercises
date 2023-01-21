namespace _01.Two_Three
{
    using System;
    using System.Text;

    public class TwoThreeTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Insert(T element)
        {
            this.root = Insert(this.root, element);
        }

        private TreeNode<T> Insert(TreeNode<T> node, T element)
        {
            if (node == null)
            {
                return new TreeNode<T>(element);

            }
            if (node.IsLeaf())
            {
                return this.MergeNodes(node, new TreeNode<T>(element));

            }

            if (isLesser(element, node.LeftKey))
            {
                var newNode = this.Insert(node.LeftChild, element);
                return newNode == node.LeftChild ? node : this.MergeNodes(node, newNode);

            }
            else if (node.IsTwoNode() || isLesser(element, node.RightKey))
            {
                var newNode = this.Insert(node.MiddleChild, element);
                return newNode == node.MiddleChild ? node : this.MergeNodes(node, newNode);

            }
            else
            {
                var newNode = this.Insert(node.RightChild, element);
                return newNode == node.RightChild ? node : this.MergeNodes(node, newNode);

            }
        }

        private bool isLesser(T element, T leftKey)
        {
            return element.CompareTo(leftKey) == -1;
        }

        private TreeNode<T> MergeNodes(TreeNode<T> current, TreeNode<T> node)
        {
            if (current.IsTwoNode())
            {
                if (isLesser(current.LeftKey, node.LeftKey))
                {
                    current.RightKey = node.LeftKey;
                    current.MiddleChild = node.LeftChild;
                    current.RightChild = node.MiddleChild;

                }
                else
                {
                    current.RightKey = current.LeftKey;
                    current.RightChild = current.MiddleChild;
                    current.MiddleChild = node.MiddleChild;
                    current.LeftChild = node.LeftChild;
                    current.LeftKey = node.LeftKey;


                }
                return current;


            }
            else if (isLesser(node.LeftKey, current.LeftKey))
            {
                var newNode = new TreeNode<T>(current.LeftKey)
                {
                    LeftChild = node,
                    MiddleChild = current
                };

                current.LeftChild = current.MiddleChild;
                current.MiddleChild = current.RightChild;
                current.LeftKey = current.RightKey;
                current.RightKey = default;
                current.RightChild = null;

                return newNode;
            }
            else if (isLesser(node.LeftKey, current.RightKey))
            {
                node.MiddleChild = new TreeNode<T>(current.RightKey)
                {
                    LeftChild = node.MiddleChild,
                    MiddleChild = current.RightChild
                };

                node.LeftChild = current;
                current.RightKey = default;
                current.RightChild = null;

                return node;
            }
            else
            {
                var newNode = new TreeNode<T>(current.RightKey)
                {
                    LeftChild = current,
                    MiddleChild = node
                };

                node.LeftChild = current.RightChild;
                current.RightKey = default;
                current.RightChild = null;

                return newNode;
            }
        }



        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }
    }
}
