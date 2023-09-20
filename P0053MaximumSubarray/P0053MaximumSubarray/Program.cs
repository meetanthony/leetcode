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
}