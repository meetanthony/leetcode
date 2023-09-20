namespace P0053MaximumSubarray;

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