using System;
using System.Threading;

namespace P21MergeTwoSortedLists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var node1 = new ListNode(Rand.Next(100));
            var node2 = new ListNode(Rand.Next(100));

            FillNodes(node1, 10);
            FillNodes(node2, 5);

            PrintNodes(node1);
            PrintNodes(node2);

            var solution = new Solution();
            var merged = solution.MergeTwoLists(node1, node2);

            PrintNodes(merged);

            Console.ReadLine();
        }

        private static void PrintNodes(ListNode node)
        {
            while (node != null)
            {
                Console.Write(node.val + " ");

                node = node.next;
            }

            Console.WriteLine();
        }

        private static readonly Random Rand = new Random(Environment.TickCount);
        private static void FillNodes(ListNode node, int count)
        {
            
            for (int i = 0; i < count; i++)
            {
                var val = node.val + Rand.Next(100);
                var next = new ListNode(val);
                node.next = next;
                node = next;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null)
                return null;

            var head = new ListNode();
            var node = head;
            var prev = node;
            while (list1 != null && list2 != null)
            {
                if (list1.val > list2.val)
                {
                    node.val = list2.val;
                    list2 = list2.next;
                }
                else
                {
                    node.val = list1.val;
                    list1 = list1.next;
                }

                node.next = new ListNode();
                prev = node;
                node = node.next;
            }

            while (list1 != null)
            {
                node.val = list1.val;
                list1 = list1.next;

                node.next = new ListNode();
                prev = node;
                node = node.next;
            }

            while (list2 != null)
            {
                node.val = list2.val;
                list2 = list2.next;

                node.next = new ListNode();
                prev = node;
                node = node.next;
            }

            prev.next = null;

            return head;
        }
    }
}