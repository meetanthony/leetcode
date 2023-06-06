using System;
using System.Collections.Generic;

namespace P0101SymmetricTree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var root = new TreeNode(
                1,
                new TreeNode(2, new TreeNode(2)),
                new TreeNode(2, null, new TreeNode(2)));

            Console.WriteLine(IsSymmetric(root));

            root.right.left = new TreeNode(31);

            Console.WriteLine(IsSymmetric(root));

            Console.ReadLine();
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

        public static bool IsSymmetric(TreeNode root)
        {
            var left = GetLeft(root.left);
            var right = GetRight(root.right);

            if (left.Count != right.Count)
                return false;
            for (int i = 0; i < left.Count; i++)
            {
                if (left[i] != right[i])
                    return false;
            }

            return true;
        }

        public static IList<int> GetLeft(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root != null)
            {
                result.Add(root.val);
                result.AddRange(GetLeft(root.left));
                result.AddRange(GetLeft(root.right));
            }
            else
            {
                result.Add(-1);
            }

            return result;
        }

        public static IList<int> GetRight(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root != null)
            {
                result.Add(root.val);
                result.AddRange(GetRight(root.right));
                result.AddRange(GetRight(root.left));
            }
            else
            {
                result.Add(-1);
            }

            return result;
        }
    }
}