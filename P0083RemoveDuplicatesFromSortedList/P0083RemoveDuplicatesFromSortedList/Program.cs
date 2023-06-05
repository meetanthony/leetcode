using System;

namespace P0083RemoveDuplicatesFromSortedList
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var list = Generate(-100, 300);
            Print(list);
            DeleteDuplicates(list);
            Print(list);

            Console.ReadLine();
        }

        private static void Print(ListNode listNode)
        {
            while (listNode != null)
            {
                Console.Write(listNode.val + " ");
                listNode = listNode.next;
            }
            Console.WriteLine();
        }

        private static ListNode Generate(int initValue, int count)
        {
            var head = new ListNode(initValue);
            var random = new Random(Environment.TickCount);
            var current = head;
            for (int i = 0; i < count; i++)
            {
                var next = new ListNode(current.val + random.Next(2));
                current.next = next;
                current = next;
            }

            return head;
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

        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return null;
            
            var currentNode = head;
            var currentVal = currentNode.val;
            while (currentNode != null)
            {
                var nextNode = currentNode.next;
                while (nextNode != null && nextNode.val == currentVal)
                {
                    nextNode = nextNode.next;
                }
                if (nextNode != null)
                    currentVal = nextNode.val;

                currentNode.next = nextNode;
                currentNode = nextNode;
            }
            return head;
        }
    }
}