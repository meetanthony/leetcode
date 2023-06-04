using System;

namespace P0069SqrtX
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.MySqrt(4));
            Console.WriteLine(solution.MySqrt(65235));
            Console.WriteLine(solution.MySqrt(20000000));
            Console.WriteLine(solution.MySqrt(int.MaxValue));
            Console.ReadLine();
        }

        public class Solution
        {
            static Solution()
            {
                for (uint i = 0; i < Squares.Length; i++)
                {
                    Squares[i] = i * i;
                }
            }

            private static readonly uint[] Squares = new uint[46342];

            public int MySqrt(int x)
            {
                for (int i = 0; i < Squares.Length - 1; i++)
                {
                    var s = Squares[i];
                    if (x == s)
                        return i;
                    if (x > s && x < Squares[i + 1])
                        return i;
                }

                return -1;
            }
        }
    }
}