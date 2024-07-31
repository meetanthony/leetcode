namespace P0001TwoSum;

internal class Program
{
    static (int[] array, int target) GetRandomArray(int numbersCount)
    {
        Random random = new Random(Environment.TickCount);

        int[] result = new int[numbersCount];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = random.Next();
        }
        
        var target = result[random.Next(numbersCount)] + result[random.Next(numbersCount)];

        return (result, target);
    }

    static void Main(string[] args)
    {
        var randomArrayAndTarget = GetRandomArray(10000);
        var array = randomArrayAndTarget.array;
        var target = randomArrayAndTarget.target;

        var solution = new Solution();
        var result = solution.TwoSum(array, target);
        Console.WriteLine(target);

        var a = array[result[0]];
        var b = array[result[1]];
        Console.Write(a + " " + b + " = " + (a + b));
        Console.ReadLine();
    }
}

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new[] { i, j };
                }
            }
        }
        return new int[0];
    }
}