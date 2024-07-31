using System.Numerics;
using System.Text;

namespace P2816DoubleANumberRepresentedAsALinkedList;

public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        var node1 = new ListNode(Rand.Next(10));

        FillNodes(node1, 10000);

        PrintNodes(node1);

        var solution = new Solution();
        var merged = solution.DoubleIt(node1);

        PrintNodes(merged);

        Console.ReadLine();
    }

    private static void PrintNodes(ListNode? node)
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
            var val = Rand.Next(10);
            var next = new ListNode(val);
            node.next = next;
            node = next;
        }
    }


    public class Solution
    {
        public ListNode DoubleIt(ListNode head)
        {
            var sb = new StringBuilder();
            ListNode? current = head;
            while (current != null)
            {
                sb.Append(current.val);
                current = current.next;
            }

            BigInteger bi = BigInteger.Parse(sb.ToString());
            bi *= 2;
            var biStr = bi.ToString();
            ListNode result = new ListNode(int.Parse(biStr[biStr.Length - 1].ToString()));
            for (int i = biStr.Length - 2; i >= 0; i--)
            {
                result = new ListNode(int.Parse(biStr[i].ToString()), result);
            }

            return result;
        }
    }
}