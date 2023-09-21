namespace P0152MaximumProductSubarray;

internal static class Stupid
{
    public static int Solve(int[] nums)
    {
        int maxProduct = int.MinValue;

        for (int i = 0; i < nums.Length; i++)
        {
            int accum = 1;
            for (int j = i; j < nums.Length; j++)
            {
                accum *= nums[j];
                if (accum > maxProduct)
                {
                    maxProduct = accum;
                }
            }
        }

        return maxProduct;
    }
}