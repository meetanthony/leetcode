namespace P0121BestTimeToBuyAndSellStock;

public static class ProfitCalculator
{
    public static int[] GetTestPrices(int pricesCount = 100000, 
        int elementsMinValue = 0,
        int elementsMaxValue = Int32.MaxValue)
    {
        var prices = new int[pricesCount];
        for (int i = 0; i < prices.Length; i++)
        {
            prices[i] = Random.Shared.Next();
        }

        return prices;
    }

    public static int MaxProfit(int[] prices)
    {
        if (prices == null ||  prices.Length == 0)
            return 0;

        int startValue = prices[0];
        int endValue = 0;
        int maxValue = 0;

        for (int currentIndex = 0; currentIndex < prices.Length; currentIndex++)
        {
            var currentValue = prices[currentIndex];

            if (currentValue < startValue)
            {
                startValue = currentValue;
                endValue = currentValue + maxValue;
                continue;
            }

            if (currentValue > endValue)
            {
                endValue = currentValue;
                var diff = currentValue - startValue;
                if (diff > maxValue)
                {
                    maxValue = diff;
                }
            }
        }

        return maxValue;
    }

    public static unsafe int MaxProfitUnsafe(int[] prices)
    {
        if (prices == null || prices.Length == 0)
            return 0;

        int maxValue = 0;

        fixed (int* pricesPointer = &prices[0])
        {
            int startValue = *pricesPointer;
            int endValue = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                int currentValue = *(pricesPointer + i);
                if (currentValue < startValue)
                {
                    startValue = currentValue;
                    endValue = currentValue + maxValue;
                    continue;
                }

                if (currentValue > endValue)
                {
                    endValue = currentValue;
                    var diff = currentValue - startValue;
                    if (diff > maxValue)
                    {
                        maxValue = diff;
                    }
                }
            }
        }

        return maxValue;
    }

    public static int MaxProfitStupid(int[] prices)
    {
        var max = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            for (int j = i + 1; j < prices.Length; j++)
            {
                if (prices[j] - prices[i] > max)
                {
                    max = prices[j] - prices[i];
                }
            }
        }

        return max;
    }
}