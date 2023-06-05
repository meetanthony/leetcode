using System;
using System.Collections.Generic;

namespace P0100SameTree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var p = new TreeNode(1, new TreeNode(1));
            var q = new TreeNode(1, null, new TreeNode(1));

            Console.WriteLine(IsSameTree(p, q));

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

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            var pnums = ListNodes(p);
            var qnums = ListNodes(q);

            if (pnums.Count != qnums.Count)
                return false;

            for (int i = 0; i < pnums.Count; i++)
            {
                if (pnums[i] != qnums[i])
                    return false;
            }

            return true;
        }

        public static IList<int> ListNodes(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root != null)
            {
                result.Add(root.val);
                result.AddRange(ListNodes(root.left));
                result.AddRange(ListNodes(root.right));
            }
            else
            {
                result.Add(int.MinValue);
            }

            return result;
        }
    }
}