using System.Diagnostics;

namespace P0053MaximumSubarray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4, 2 };
            //var nums = new int[] { -2, 1 };
            SolveAndPrint(nums);

            nums = TestArrayGenerator.Generate(10000, -10000, 0);
            SolveAndPrint(nums);

            Console.ReadLine();
        }

        private static void SolveAndPrint(int[] nums)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var solve = Stupid.Solve(nums);
            Console.WriteLine(solve + " " + stopwatch.Elapsed);
            stopwatch.Restart();
            var solve2 = Stupid.Solve2(nums);
            Console.WriteLine(solve2 + " " + stopwatch.Elapsed);
            stopwatch.Restart();
            var solve3 = Caterpillar.Solve(nums);
            Console.WriteLine(solve3 + " " + stopwatch.Elapsed);
        }
    }

    static class TestArrayGenerator
    {
        public static int[] Generate(int elementsCount = 10000,
            int elementsMinValue = Int32.MinValue,
            int elementsMaxValue = Int32.MaxValue, bool exceptZeros = false)
        {
            var testArray = new int[elementsCount];
            for (int i = 0; i < testArray.Length; i++)
            {
                var value = Random.Shared.Next(elementsMinValue, elementsMaxValue + 1);
                if (exceptZeros && value == 0)
                {
                    i--;
                    continue;
                }

                testArray[i] = value;
            }

            return testArray;
        }
    }

    static class Caterpillar
    {
        public static int Solve(int[] nums)
        {
            int maxSum = Int32.MinValue;

            int pointer = 0;
            int sum = 0;

            while (pointer < nums.Length)
            {
                sum += nums[pointer];
                if (sum > maxSum)
                    maxSum = sum;
                if (sum < 0)
                    sum = 0;
                pointer++;
            }

            return maxSum;
        }
    }

    internal static class Stupid
    {
        public static int Solve(int[] nums)
        {
            int maxSum = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                int accum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    accum += nums[j];
                    if (accum > maxSum)
                    {
                        maxSum = accum;
                    }
                }
            }

            return maxSum;
        }

        public static int Solve2(int[] nums)
        {
            int maxSum = int.MinValue;

            for (int i = 0; i < nums.Length;)
            {
                int accum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    accum += nums[j];
                    if (accum > maxSum)
                    {
                        maxSum = accum;
                    }
                }

                accum -= nums[i];
                i++;

                for (int j = nums.Length - 1; j >= i; j--)
                {
                    if (accum > maxSum)
                    {
                        maxSum = accum;
                    }
                    accum -= nums[j];
                }

                i++;
            }

            return maxSum;
        }
    }
}