// See https://aka.ms/new-console-template for more information

{
    var solution = new Solution();
    var nums = new[] { 1, 1, 1, 2, 2, 3 };
    Print(nums);
    Console.WriteLine();
    var ks = solution.TopKFrequent(nums, 2);
    Print(ks);

    nums = new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6, 7, 7, 8, 2, 3, 1, 1, 1, 10, 11, 5, 6, 2, 4, 7, 8, 5, 6 };
    Print(nums);
    Console.WriteLine();
    ks = solution.TopKFrequent(nums, 10);
    Print(ks);
}

void Print(int[] nums)
{
    foreach (var num in nums)
    {
        Console.Write(num + " ");
    }

    Console.WriteLine();
}

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        IDictionary<int, int> stats = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (stats.ContainsKey(num))
                stats[num] += 1;
            else
                stats[num] = 1;
        }

        var statArray = stats.ToArray();
        Array.Sort(statArray, new StatsComparer());
        List<int> result = new List<int>(k);
        for (int i = 0; i < k; i++)
        {
            if (i >= statArray.Length)
                break;
            result.Add(statArray[i].Key);
        }

        return result.ToArray();
    }

    private class StatsComparer : IComparer<KeyValuePair<int, int>>
    {
        public int Compare(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
        {
            return y.Value - x.Value;
        }
    }
}