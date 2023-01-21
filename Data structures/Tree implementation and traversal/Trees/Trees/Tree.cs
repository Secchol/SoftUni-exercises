using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Tree<T>
    {
        public T Value { get; set; }
        public List<Tree<T>> Children { get; set; }
        public Tree<T> Parent { get; set; }

        public Tree(T value)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
        }
        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this.Children.Add(child);

            }

        }
    }
}
