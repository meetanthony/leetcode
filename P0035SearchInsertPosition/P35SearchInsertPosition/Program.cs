using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P35SearchInsertPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SearchInsert(new[] {1, 3, 5, 6}, 5));
            Console.WriteLine(SearchInsert(new[] { 1, 3, 5, 6 }, 2));
            Console.WriteLine(SearchInsert(new[] { 1, 3, 5, 6 }, 7));
            Console.WriteLine(SearchInsert(new[] { 9 }, 7));

            Console.ReadLine();
        }

        public static int SearchInsert(int[] nums, int target)
        {
            if (nums[nums.Length - 1] < target)
                return nums.Length;
            if (nums[0] > target)
                return 0;

            return SearchInsert(nums, target, 0, nums.Length-1);
        }

        private static int SearchInsert(int[] nums, int target, int left, int right)
        {
            if (nums[left] == target)
                return left;
            if (nums[right] == target)
                return right;

            if (right - left <= 1)
            {
                if (nums[left] <= target)
                    return right;
                return left;
            }

            var middleIndex = left + (right - left)/2;
            var middle = nums[middleIndex];

            if (middle == target)
                return middleIndex;

            if (middle > target)
            {
                return SearchInsert(nums, target, left, middleIndex);
            }
            
            return SearchInsert(nums, target, middleIndex, right);
        }
    }
}
