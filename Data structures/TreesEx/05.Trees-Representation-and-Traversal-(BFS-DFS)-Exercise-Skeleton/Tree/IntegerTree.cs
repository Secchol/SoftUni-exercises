namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            var result = new List<List<int>>();
            var currentPath = new LinkedList<int>();
            currentPath.AddFirst(this.Key);
            int currentSum = this.Key;
            this.DFS(this, result, currentPath, ref currentSum, sum);
            return result;
        }

        private void DFS(Tree<int> integerTree, List<List<int>> result, LinkedList<int> currentPath, ref int currentSum, int wantedSum)
        {
            foreach (var child in integerTree.Children)
            {
                currentSum += child.Key;
                currentPath.AddLast(child.Key);
                this.DFS(child, result, currentPath, ref currentSum, wantedSum);
            }
            if (currentSum == wantedSum)
            {
                result.Add(new List<int>(currentPath));

            }

            currentSum -= integerTree.Key;
            currentPath.RemoveLast();
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            var result = new List<Tree<int>>();
            var currentTree = new Tree<int>();
            int currentSum = 0;
            this.DFSForSubtrees(this, result, currentTree, ref currentSum, sum);
            return result;
        }

        private IEnumerable<Tree<int>> DFSForSubtrees(Tree<int> tree, List<Tree<int>> result, Tree<int> currentTree, ref int currentSum, int sum)
        {

            foreach (var child in tree.Children)
            {
                currentSum += child.Key;
                //currentPath.AddLast(child.Key);
                this.DFSForSubtrees(child, result, currentTree, ref currentSum, sum);
            }
            if (currentSum == sum)
            {
                //result.Add(new List<int>(currentPath));

            }

            //currentSum -= integerTree.Key;
            currentPath.RemoveLast();
        }
    }
}
