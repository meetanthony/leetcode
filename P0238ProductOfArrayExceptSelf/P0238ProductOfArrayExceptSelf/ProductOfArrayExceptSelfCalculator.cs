namespace P0238ProductOfArrayExceptSelf;

public static class ProductOfArrayExceptSelfCalculator
{
    public static int[] GetTestArray(int elementsCount = 10000,
        int elementsMinValue = Int32.MinValue,
        int elementsMaxValue = Int32.MaxValue, bool exceptZeros = false)
    {
        var testArray = new int[elementsCount];
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

    public static int[] ProductExceptSelfStupid(int[] nums)
    {
        var elementsCount = nums.Length;

        int[] result = new int[elementsCount];

        for (int i = 0; i < elementsCount; i++)
        {
            long product = 1;
            for (int j = 0; j < elementsCount; j++)
            {
                if (i == j)
                    continue;

                product *= nums[j];

                if (product == 0)
                {
                    break;
                }
            }

            result[i] = (int)product;
        }

        return result;
    }

    public static int[] ProductExceptSelfWithDivisor(int[] nums)
    {
        var elementsCount = nums.Length;

        int[] result = new int[elementsCount];
        int product = 1;

        bool zeroFound = false;
        for (int i = 0; i < elementsCount; i++)
        {
            if (nums[i] == 0)
            {
                if (zeroFound)
                    return new int[elementsCount];
                zeroFound = true;
                continue;
            }

            product *= nums[i];
        }

        for (int i = 0; i < elementsCount; i++)
        {
            var value = nums[i];
            if (value == 0)
                result[i] = product;
            else if (zeroFound)
                result[i] = 0;
            else
                result[i] = product / nums[i];
        }

        return result;
    }

    public static int[] ProductExceptSelf(int[] nums)
    {
        var elementsCount = nums.Length;

        int[] result = new int[elementsCount];
        result[0] = 1;
        result[elementsCount - 1] = 1;
        int product = 1;
        for (int i = 1; i < elementsCount; i++)
        {
            product *= nums[i-1];
            result[i] = product;
        }

        product = 1;
        for (int i = elementsCount - 2; i >= 0; i--)
        {
            product *= nums[i+1];
            result[i] *= product;
        }

        return result;
    }
}