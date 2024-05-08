using System.Diagnostics;

namespace P0198HouseRobber;

/// <summary>
/// https://leetcode.com/problems/house-robber/
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Rob(i);
            }
        }

        Console.ReadLine();
    }

    private static int Rob(IRobber robber, int[] nums)
    {
        var sw = Stopwatch.StartNew();
        var result = robber.Rob(nums);
        var et = sw.Elapsed;

        Console.Write($"{robber.GetType()} {result} {robber.IterationsComplete} ");
        Console.WriteLine(et.ToString());
        Console.WriteLine();

        return result;
    }

    private static void Rob(int houseCount)
    {
        Console.WriteLine(houseCount);

        var nums = new int[houseCount];
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = Random.Shared.Next(10);
        }

        var res0 = Rob(new StupidSolution(), nums);
        var res1 = Rob(new Solution(), nums);

        if (res0 != res1)
            throw new Exception();
    }
}