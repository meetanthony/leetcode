using System;

namespace P0070ClimbingStairs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            for (int i = 1; i <= 45; i++)
            {
                Console.WriteLine(ClimbStairs(i));
            }

            Console.WriteLine("Done!");

            Console.ReadLine();
        }

        public static int ClimbStairs(int n)
        {
            var sum = 0;
            var p = 0;
            var pp = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    sum += 1;
                    continue;
                }

                if (i == 1)
                {
                    sum = 2;
                    pp = 1;
                    p = 2;
                    continue;
                }

                sum = p + pp;
                pp = p;
                p = sum;
            }
            return sum;
        }

        public static int ClimbStairs1(int n)
        {
            if (n == 1)
                return 1;
            if (n == 2)
                return 2;
            return ClimbStairs(n - 2) + ClimbStairs(n - 1);
        }

        public static int ClimbStairs2(int n)
        {
            var result = 1;
            int iteration = 1;
            while (iteration * 2 < n)
            {
                ulong val = 0;
                var ones = n - iteration * 2;
                for (int i = 0; i < iteration; i++)
                {
                    val |= 1u << (ones + i);
                }

                while (val > 0)
                {
                    var bitsCounter = 0;
                    for (int i = 0; i < ones + iteration; i++)
                    {
                        if (((val >> i) & 1) == 1)
                        {
                            bitsCounter++;
                            if (bitsCounter > iteration)
                                break;
                        }
                    }

                    if (bitsCounter == iteration)
                        result += 1;

                    val--;
                }
                iteration++;
            }

            if (n % 2 == 0)
                result += 1;

            return result;
        }
    }
}