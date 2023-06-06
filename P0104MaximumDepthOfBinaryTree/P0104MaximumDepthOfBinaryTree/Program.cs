using System;

namespace P0104MaximumDepthOfBinaryTree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var root = new TreeNode(1,
                new TreeNode(2, new TreeNode(3)),
                new TreeNode(2, null, new TreeNode(3, null, new TreeNode(4))));
            Console.Write(MaxDepth(root));
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

        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            var left = 1 + MaxDepth(root.left);
            var right = 1 + MaxDepth(root.right);

            return left > right ? left : right;
        }
    }
}