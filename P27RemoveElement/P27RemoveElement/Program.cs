using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P27RemoveElement
{
    class Program
    {
        static void Main(string[] args)
        {
            //var nums = new[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            var nums = new int[0];
            var count = RemoveElement(nums, 5);
            Console.WriteLine(count);
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(nums[i]);
            }

            Console.ReadLine();
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int[] temp = new int[nums.Length];
            int currentPos = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    temp[currentPos] = nums[i];
                    currentPos++;
                }
            }

            if (currentPos != nums.Length)
                Array.Copy(temp, nums, currentPos+1);
            return currentPos;
        }
    }
}
