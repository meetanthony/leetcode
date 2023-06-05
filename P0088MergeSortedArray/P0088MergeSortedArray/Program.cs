using System;

namespace P0088MergeSortedArray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var m = 10;
            var n = 5;

            var num1 = GenerateNum1(m, n);
            Print(num1);
            var num2 = GenerateNum2(n);
            Print(num2);

            Merge(num1, m, num2, n);
            Print(num1);

            Console.ReadLine();
        }

        private static readonly Random Random = new Random(Environment.TickCount);

        private static int[] GenerateNum1(int m, int n)
        {
            int[] nums = new int[m + n];
            int currentValue = 0;
            for (int i = 0; i < m; i++)
            {
                nums[i] = currentValue;
                currentValue += Random.Next(2);
            }

            return nums;
        }

        private static int[] GenerateNum2(int n)
        {
            int[] nums = new int[n];
            int currentValue = 0;
            for (int i = 0; i < n; i++)
            {
                nums[i] = currentValue;
                currentValue += Random.Next(2);
            }

            return nums;
        }

        private static void Print(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }

            Console.WriteLine();
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var n1 = 0;
            var n2 = 0;
            while (n2 < n)
            {
                if (n1 >= m+n2)
                {
                    Array.Copy(nums2, n2, nums1, n1, nums2.Length-n2);

                    break;
                }
                
                if (nums1[n1] >= nums2[n2])
                {
                    Array.Copy(nums1, n1, nums1, n1 + 1, m - (n1 - n2));
                    nums1[n1] = nums2[n2];
                    n2 += 1;
                    n1 += 1;
                }
                else
                {
                    n1 += 1;
                }
            }
        }
    }
}