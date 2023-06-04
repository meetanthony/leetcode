using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P217ContainsDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ContainsDuplicate(new[] { 1, 2, 3, 1 }));
            Console.WriteLine(ContainsDuplicate(new[] { 1, 2, 3, 4 }));
            Console.WriteLine(ContainsDuplicate(new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }));

            Console.ReadLine();
        }

        public static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> hashSet = new HashSet<int>();
            foreach (var num in nums)
            {
                if (hashSet.Contains(num))
                    return true;
                hashSet.Add(num);
            }
            return false;
        }
    }
}
