using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P66PlusOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = PlusOne(new[] {9});
            for (int i = 0; i < r.Length; i++)
            {
                Console.Write(r[i]);
            }

            Console.ReadLine();
        }

        public static int[] PlusOne(int[] digits)
        {
            var result = new Stack<int>(digits.Length);
            var lastVal = digits[digits.Length - 1];
            lastVal += 1;
            result.Push(lastVal%10);
            for (int i = digits.Length - 2; i >= 0; i--)
            {
                var currentVal = digits[i];
                lastVal = currentVal + lastVal/10;
                result.Push(lastVal%10);
            }
            if (lastVal>9)
                result.Push(1);
            return result.ToArray();
        }
    }
}
