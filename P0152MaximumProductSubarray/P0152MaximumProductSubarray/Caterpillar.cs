namespace P0152MaximumProductSubarray;

public static class Caterpillar
{
    public static int SolveFromBorders(int[] nums)
    {
        int max = nums[0];
        int current = 1, second = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            current = (current == 0 ? 1 : current) * nums[i];
            second = (second == 0 ? 1 : second) * nums[nums.Length - 1 - i];
            max = Math.Max(max, Math.Max(current, second));
        }
        return max;
    }
        
    public static int SolveSequentially(int[] nums)
    {
        int maxProduct = Int32.MinValue;

        int pointer = 0;

        int product = 0;
        int begin = 0;
        while (pointer < nums.Length)
        {
            var value = nums[pointer];

            if (value == 0)
            {
                while (pointer-1 != begin && product < 0)
                {
                    product /= nums[begin];
                    begin++;
                }
                if (product > maxProduct)
                    maxProduct = product;
            }

            if (product == 0)
            {
                product = value;
                begin = pointer;
            }
            else
            {
                product *= value;
            }

            if (product > maxProduct)
                maxProduct = product;

            pointer++;
        }

        while (pointer-1 != begin && product < 0)
        {
            product /= nums[begin];
            begin++;
        }
        if (product > maxProduct)
            maxProduct = product;

        return maxProduct;
    }
}