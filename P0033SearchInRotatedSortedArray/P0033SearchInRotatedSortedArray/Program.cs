namespace P0033SearchInRotatedSortedArray;

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

        ITargetSearcher stupid = new Stupid();
        ITargetSearcher solution = new Solution();
        for (long startNumber = minStartNumber; startNumber <= maxStartNumber; startNumber += startNumberIncrement)
        {
            for (int itemsCount = minItemsCount; itemsCount < maxItemsCount; itemsCount++)
            {
                for (int rotateCount = minRotateCount; rotateCount < itemsCount - 1; rotateCount++)
                {
                    var rotatedArray = GetRotatedArray(itemsCount, (int)startNumber, rotateCount);

                    var target = 0;
                    if (rotatedArray.Length > 0)
                        target = rotatedArray[Random.Shared.Next(rotatedArray.Length)];

                    var stupidResult = stupid.Search(rotatedArray, target);

                    var solutionResult = solution.Search(rotatedArray, target);
                    if (stupidResult != solutionResult)
                        throw new Exception();
                }
            }
        }
    }
}

public interface ITargetSearcher
{
    int Search(int[] nums, int target);
}

public class Stupid : ITargetSearcher
{
    public int Search(int[] nums, int target)
    {
        if (nums.Length == 0)
            return 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if (num == target)
                return nums.Length - i;
        }

        return -1;
    }
}

public class Solution : ITargetSearcher
{
    public int Search(int[] nums, int target)
    {
        if (nums.Length == 0)
            return -1;
        
        if (nums.Length == 1)
            return nums[0] == target ? nums.Length : -1;

        var l = 0;
        var r = nums.Length - 1;
        if (nums[l] > target && nums[r] < target)
            return -1;

        if (nums[l] == target)
            return nums.Length;

        if (nums[r] == target)
            return 1;

         int shiftPart = nums.Length / 2;
        int end = nums[nums.Length - 1];
        while (shiftPart > 0)
        {
            if (nums[l] > end)
                l += shiftPart;
            else if (nums[l] < end)
                if (nums[l] > target)
                    l -= shiftPart;
                else if (nums[l] < target)
                    l += shiftPart;

            if (nums[l] == target)
                return nums.Length - l;

            shiftPart /= 2;
        }

        return -1;
    }
}