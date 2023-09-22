namespace Common.TestData;

public static class TestArrayGenerator
{
    public static int[] GetAscendingArray(int itemsCount, int start = 0, int maxIncrement = 1)
    {
        int[] nums = new int[itemsCount];
        for (int i = 0; i < itemsCount; i++)
        {
            nums[i] = start;
            start += Random.Shared.Next(1, maxIncrement + 1);
        }

        return nums;
    }

    public static int[] GetDescendingArray(int itemsCount, int start = 0, int maxIncrement = 1)
    {
        int[] nums = new int[itemsCount];
        for (int i = 0; i < itemsCount; i++)
        {
            nums[i] = start;
            start -= Random.Shared.Next(1, maxIncrement + 1);
        }

        return nums;
    }

    public static int[] RotateArray(int[] nums, int rotateTimes)
    {
        var rotatedNums = new int[nums.Length];
        for (int i = 0; i < rotatedNums.Length; i++)
        {
            rotatedNums[i] = nums[(i + rotateTimes) % nums.Length];
        }

        return rotatedNums;
    }

    public static int[] GetAscendingRotatedArray(int itemsCount, int minValue, int rotateTimes)
    {
        var nums = GetAscendingArray(itemsCount, minValue);
        var rotatedNums = RotateArray(nums, rotateTimes);
        return rotatedNums;
    }
    public static int[] GetDescendingRotatedArray(int itemsCount, int minValue, int rotateTimes)
    {
        var nums = GetDescendingArray(itemsCount, minValue);
        var rotatedNums = RotateArray(nums, rotateTimes);
        return rotatedNums;
    }

    public static int[] GetRandomArray(int itemsCount = 10000,
        int elementsMinValue = Int32.MinValue,
        int elementsMaxValue = Int32.MaxValue, bool exceptZeros = false)
    {
        var testArray = new int[itemsCount];
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