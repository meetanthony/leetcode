using P0121BestTimeToBuyAndSellStock;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void LeetcodeExample1Test()
        {
            var prices = new[] { 7, 1, 5, 3, 6, 4 };
            var expectedResult = 5;

            Assert.Equal(expectedResult, ProfitCalculator.MaxProfitStupid(prices));
            Assert.Equal(expectedResult, ProfitCalculator.MaxProfit(prices));
            Assert.Equal(expectedResult, ProfitCalculator.MaxProfitUnsafe(prices));
        }

        [Fact]
        public void LeetcodeExample2Test()
        {
            var prices = new[] { 7, 6, 4, 3, 1 };
            var expectedResult = 0;

            Assert.Equal(expectedResult, ProfitCalculator.MaxProfitStupid(prices));
            Assert.Equal(expectedResult, ProfitCalculator.MaxProfit(prices));
            Assert.Equal(expectedResult, ProfitCalculator.MaxProfitUnsafe(prices));
        }

        [Fact]
        public void RandomTest()
        {
            for (int i = 0; i < 100; i++)
            {
                var prices = ProfitCalculator.GetTestPrices(100);
                var expectedResult = ProfitCalculator.MaxProfitStupid(prices);

                Assert.Equal(expectedResult, ProfitCalculator.MaxProfit(prices));
                Assert.Equal(expectedResult, ProfitCalculator.MaxProfitUnsafe(prices));
            }
        }

        [Fact]
        public void ZeroPricesTest()
        {
            int[] prices = Array.Empty<int>();
            var expectedResult = 0;

            Assert.Equal(expectedResult, ProfitCalculator.MaxProfitStupid(prices));
            Assert.Equal(expectedResult, ProfitCalculator.MaxProfit(prices));
            Assert.Equal(expectedResult, ProfitCalculator.MaxProfitUnsafe(prices));
        }
    }
}