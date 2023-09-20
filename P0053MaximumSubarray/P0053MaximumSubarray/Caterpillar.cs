namespace P0053MaximumSubarray;

internal static class Caterpillar
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