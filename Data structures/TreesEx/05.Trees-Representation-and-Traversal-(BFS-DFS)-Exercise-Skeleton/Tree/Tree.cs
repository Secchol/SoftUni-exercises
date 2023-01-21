namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {

        private List<Tree<T>> children;
        public Tree(T key = default, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.AddChild(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children { get { return this.children; } }

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);

        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;

        }

        public string AsString()
        {
            var sb = new StringBuilder();
            this.DfsAsString(sb, this, 0);
            return sb.ToString().Trim();
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int level)
        {
            sb.Append(new String(' ', level)).AppendLine(tree.Key.ToString());
            foreach (var child in tree.Children)
            {
                DfsAsString(sb, child, level + 2);
            }
        }

        public IEnumerable<T> GetInternalKeys()
        {
            List<T> keys = new List<T>();
            FindInternalKeys(keys, this);
            return keys;
        }

        private void FindInternalKeys(List<T> keys, Tree<T> tree)
        {
            foreach (Tree<T> child in tree.Children)
            {
                if (child.Children.Count > 0)
                {
                    keys.Add(child.Key);

                }
                FindInternalKeys(keys, child);

            }
        }

        public IEnumerable<T> GetLeafKeys()
        {
            List<Tree<T>> keys = new List<Tree<T>>();
            FindLeafKeys(keys, this);
            return keys.Select(x => x.Key);
        }

        private void FindLeafKeys(List<Tree<T>> keys, Tree<T> tree)
        {
            foreach (var child in tree.Children)
            {
                if (child.Children.Count == 0)
                    keys.Add(child);
                else
                    FindLeafKeys(keys, child);

            }
        }

        public T GetDeepestKey()
        {
            return GetLastKey(this).Key;
        }

        private Tree<T> GetLastKey(Tree<T> tree)
        {
            List<Tree<T>> keys = new List<Tree<T>>();
            FindLeafKeys(keys, this);

            Tree<T> deepestNode = new Tree<T>(default);
            int maxDepth = 0;

            foreach (var key in keys)
            {
                int currentDepth = GetDepth(key);
                if (currentDepth > maxDepth)
                {
                    maxDepth = currentDepth;
                    deepestNode = key;

                }
            }
            return deepestNode;
        }

        private int GetDepth(Tree<T> key)
        {
            var tree = key;
            int depth = 0;
            while (tree.Parent != null)
            {
                depth++;
                tree = tree.Parent;

            }
            return depth;
        }

        public IEnumerable<T> GetLongestPath()
        {
            Tree<T> deepestKey = GetLastKey(this);
            List<T> path = new List<T>();
            while (deepestKey.Parent != null)
            {
                path.Add(deepestKey.Key);
                deepestKey = deepestKey.Parent;

            }
            path.Add(deepestKey.Key);
            path.Reverse();
            return path;
        }
    }
}
