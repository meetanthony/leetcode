namespace P0153FindMinimumInRotatedSortedArray;

internal class Program
{
    private static int[] GetRotatedArray(int itemsCount, int startNumber, int rotateCount)
    {
        if (itemsCount == 0)
            return Array.Empty<int>();

        int[] result = new int[itemsCount];
        var firstElementIndex = result.Length - rotateCount;
        for (int i = 0; i < firstElementIndex; i++)
        {
            result[i] = i + startNumber + rotateCount;
        }

        for (int i = firstElementIndex; i < result.Length; i++)
        {
            result[i] = startNumber + (i - firstElementIndex);
        }

        return result;
    }

    private static void PrintArray(int[] array)
    {
        foreach (var i in array)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }

    private static void Main(string[] args)
    {
        const int minItemsCount = 0;
        const int maxItemsCount = 10;
        const int minRotateCount = 0;
        const int minStartNumber = int.MinValue;
        const int maxStartNumber = int.MaxValue;
        const int startNumberIncrement = int.MaxValue / 16;

        IMinimumFinder stupid = new Stupid();
        IMinimumFinder stupid2 = new Stupid2();
        IMinimumFinder solution = new Solution();
        for (long startNumber = minStartNumber; startNumber <= maxStartNumber; startNumber += startNumberIncrement)
        {
            for (int itemsCount = minItemsCount; itemsCount < maxItemsCount; itemsCount++)
            {
                for (int rotateCount = minRotateCount; rotateCount < itemsCount - 1; rotateCount++)
                {
                    var rotatedArray = GetRotatedArray(itemsCount, (int)startNumber, rotateCount);

                    var stupidResult = stupid.FindMin(rotatedArray);

                    var solutionResult = solution.FindMin(rotatedArray);
                    if (stupidResult != solutionResult)
                        throw new Exception();

                    var stupid2Result = stupid2.FindMin(rotatedArray);
                    if (stupidResult != stupid2Result)
                        throw new Exception();
                }
            }
        }
    }
}

public interface IMinimumFinder
{
    int FindMin(int[] nums);
}

public class Stupid : IMinimumFinder
{
    public int FindMin(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        var min = int.MaxValue;
        foreach (var num in nums)
        {
            if (num < min)
                min = num;
        }
        return min;
    }
}

public class Stupid2 : IMinimumFinder
{
    public int FindMin(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        Array.Sort(nums);

        return nums[0];
    }
}

public class Solution : IMinimumFinder
{
    public int FindMin(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        if (nums.Length == 1)
            return nums[0];

        if (nums.Length == 2)
            return Math.Min(nums[0], nums[1]);

        var l = 0;
        var r = nums.Length - 1;
        int oldL = l;
        while (r - l > 1)
        {
            var lv = nums[l];
            var rv = nums[r];
            if (lv > rv)
            {
                oldL = l;
                l += (r - l) / 2;
            }
            else if (rv > lv)
            {
                r = l;
                l = oldL;
            }
        }

        return Math.Min(nums[r], nums[l]);
    }
}