using System.Diagnostics;

namespace P0121BestTimeToBuyAndSellStock
{
    public class Program
    {
        private static void Main(string[] args)
        {
            const int testIterations = 10;

            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0; i < testIterations; i++)
            {
                var prices = ProfitCalculator.GetTestPrices();

                stopwatch.Restart(); 
                ProfitCalculator.MaxProfit(prices);
                Console.WriteLine("MaxProfit: " + stopwatch.Elapsed);

                prices = ProfitCalculator.GetTestPrices();
                stopwatch.Restart();
                ProfitCalculator.MaxProfitUnsafe(prices);
                Console.WriteLine("MaxProfitUnsafe: " + stopwatch.Elapsed);

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}