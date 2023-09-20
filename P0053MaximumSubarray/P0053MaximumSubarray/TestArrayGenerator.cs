namespace P0053MaximumSubarray;

internal static class TestArrayGenerator
{
    public static int[] Generate(int elementsCount = 10000,
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
}