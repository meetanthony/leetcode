using Common.TestData;
using System.Diagnostics;

namespace P0152MaximumProductSubarray
{
    internal class Program
    {
        private delegate int SolveDelegate(int[] nums);

        private static void Main(string[] args)
        {
            const int minPossibleValue = -4;
            const int maxPossibleValue = 3;
            const int startElementsCount = 5;
            const int endElementsCount = 10;
            const bool print = false;

            Console.WriteLine("Checking...");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 5; i < 10; i++)
            {
                var brutforceArrays = new BruteForceArrays<int>(i, minPossibleValue, maxPossibleValue);
                Console.WriteLine("Cases count: " + brutforceArrays.CasesCount);
                foreach (var array in brutforceArrays)
                {
                    Check(array, print);
                }
            }
            Console.WriteLine($"Checked {stopwatch.Elapsed}");

            Console.WriteLine("Benching...");

            var stupidTime = Bench(Stupid.Solve, startElementsCount, endElementsCount,
                minPossibleValue, maxPossibleValue);
            var fromBordersTime = Bench(Caterpillar.SolveFromBorders, startElementsCount, endElementsCount,
                minPossibleValue, maxPossibleValue);
            var sequentiallyTime = Bench(Caterpillar.SolveSequentially, startElementsCount, endElementsCount,
                minPossibleValue, maxPossibleValue);

            Console.WriteLine($"Stupid.Solve:                  {stupidTime}");
            Console.WriteLine($"Caterpillar.SolveFromBorders:  {fromBordersTime}");
            Console.WriteLine($"Caterpillar.SolveSequentially: {sequentiallyTime}");

            Console.WriteLine("Benched. Press any key to end the program");

            Console.ReadKey();
        }

        private static TimeSpan Bench(SolveDelegate solveDelegate, int startElementsCount, int endElementsCount,
            int minPossibleValue, int maxPossibleValue)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = startElementsCount; i < endElementsCount; i++)
            {
                var brutforceArrays = new BruteForceArrays<int>(i, minPossibleValue, maxPossibleValue);
                foreach (var array in brutforceArrays)
                {
                    solveDelegate(array);
                }
            }

            return stopwatch.Elapsed;
        }

        private static bool Check(int[] nums, bool print)
        {
            var solveStupid = Stupid.Solve(nums);
            var solveFromBorders = Caterpillar.SolveFromBorders(nums);
            var solveSequentially = Caterpillar.SolveSequentially(nums);

            if (print)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    Console.Write(nums[i] + " ");
                }
                Console.WriteLine();

                Console.WriteLine(solveStupid);
                Console.WriteLine(solveFromBorders);
                Console.WriteLine(solveSequentially);

                Console.WriteLine();
            }

            return solveSequentially == solveStupid && solveStupid == solveFromBorders;
        }
    }
}