namespace Trees
{
    using System;
    using System.Collections.Generic;

    public class Main
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Node<int>[] treeNodes = new Node<int>[n];

            for (int i = 0; i < n; i++)
            {
                treeNodes[i] = new Node<int>(i);
            }

            for (int i = 0; i < n - 1; i++)
            {
                var pair = Console.ReadLine().Split();
                int parentValue = int.Parse(pair[0]);
                int childValue = int.Parse(pair[1]);

                treeNodes[parentValue].Value = parentValue;
                treeNodes[childValue].Value = childValue;

                treeNodes[parentValue].Children.Add(treeNodes[childValue]);
                treeNodes[childValue].IsChild = true;
            }

            Console.WriteLine("Root: " + FindRoot(treeNodes).Value);
            Console.WriteLine("Leaves: " + string.Join(", ", FindLeaves(treeNodes)));
            Console.WriteLine("Middle nodes: " + string.Join(", ", FindMiddleNodes(treeNodes)));
            Console.WriteLine("Longest path: " + FindLongestPath(FindRoot(treeNodes)));
        }

        private static Node<int> FindRoot(Node<int>[] treeNodes)
        {
            var isChild = new bool[treeNodes.Length];
            for (int i = 0; i < treeNodes.Length; i++)
            {
                if (treeNodes[i].IsChild)
                {
                    isChild[i] = true;
                }
            }

            for (int i = 0; i < isChild.Length; i++)
            {
                if (isChild[i] == false)
                {
                    return treeNodes[i];
                }
            }

            throw new ArgumentException("Cannot find root");
        }

        public static List<int> FindLeaves(Node<int>[] treeNodes)
        {
            List<int> leaves = new List<int>();
            foreach (var item in treeNodes)
            {
                if (item.Children.Count == 0)
                {
                    leaves.Add(item.Value);
                }
            }

            return leaves;
        }

        public static List<int> FindMiddleNodes(Node<int>[] treeNodes)
        {
            List<int> middleNodes = new List<int>();
            var root = FindRoot(treeNodes);

            foreach (var item in treeNodes)
            {
                if (item.Children.Count > 0 && item != root)
                {
                    middleNodes.Add(item.Value);
                }
            }

            return middleNodes;
        }

        private static int FindLongestPath(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0; 
            }
            int maxPath = 0;
            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }
            return maxPath + 1;
        }
    }
}
