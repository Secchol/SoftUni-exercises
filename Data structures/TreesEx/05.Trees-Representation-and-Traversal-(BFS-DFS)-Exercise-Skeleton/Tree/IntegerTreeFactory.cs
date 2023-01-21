namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class IntegerTreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public IntegerTreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (string item in input)
            {
                int[] split = item.Split(' ').Select(int.Parse).ToArray();
                int parent = split[0];
                int child = split[1];
                this.AddEdge(parent, child);

            }
            return this.GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            if (!this.nodesByKey.ContainsKey(key))
            {
                this.nodesByKey[key] = new IntegerTree(key);

            }

            return this.nodesByKey[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = CreateNodeByKey(parent);
            var childNode = CreateNodeByKey(child);
            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        public IntegerTree GetRoot()
        {
            foreach (var kvp in this.nodesByKey)
            {
                if (kvp.Value.Parent == null)
                {
                    return kvp.Value;

                }
            }
            return null;
        }
    }
}
