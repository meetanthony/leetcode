using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P26RemoveDuplicatesFromSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var ar = new int[] {0, 0, 1, 1, 1, 1, 2, 3, 4, 4, 4, 5, 5, 5, 6, 7, 8, 9};
            var unCount = RemoveDuplicates(ar);
            for (int i = 0; i < unCount; i++)
            {
                Console.WriteLine(ar[i]);
            }

            Console.ReadKey();
        }

        public static int RemoveDuplicates(int[] nums)
        {
            int currentIndex = 1;
            int currentValue = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != currentValue)
                {
                    currentValue = nums[i];
                    nums[currentIndex] = currentValue;
                    currentIndex++;
                }
            }

            return currentIndex;
        }
    }
}
