using System;
using System.Collections.Generic;

namespace P0094BinaryTreeInorderTraversal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var root = new TreeNode();
            Generate(root, 50);
            var nums = InorderTraversal(root);
            for (int i = 0; i < nums.Count; i++)
            {
                Console.Write(nums[i] + " ");
            }

            Console.ReadLine();
        }

        private static readonly Random Random = new Random(Environment.TickCount);

        private static int _currentValue = 0;

        private static void Generate(TreeNode root, int chancePercent)
        {
            if (Random.Next(100) > chancePercent)
            {
                _currentValue += 1;
                TreeNode treeNode = new TreeNode();
                treeNode.val = _currentValue;
                root.left = treeNode;
                Generate(treeNode, chancePercent);
            }
            if (Random.Next(100) > chancePercent)
            {
                _currentValue += 1;
                TreeNode treeNode = new TreeNode();
                treeNode.val = -_currentValue;
                root.right = treeNode;
                Generate(treeNode, chancePercent);
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public static IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root != null)
            {
                result.AddRange(InorderTraversal(root.left));
                result.Add(root.val);
                result.AddRange(InorderTraversal(root.right));
            }

            return result;
        }
    }
}