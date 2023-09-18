using System.Diagnostics;

namespace P0238ProductOfArrayExceptSelf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var printArrays = true;
            var nums = new int[] { 1, 2, 3, 4 };
            ProcessNums(ProductOfArrayExceptSelfCalculator.ProductExceptSelfStupid, nums, printArrays);
            ProcessNums(ProductOfArrayExceptSelfCalculator.ProductExceptSelfWithDivisor, nums, printArrays);
            ProcessNums(ProductOfArrayExceptSelfCalculator.ProductExceptSelf, nums, printArrays);

            nums = ProductOfArrayExceptSelfCalculator
                .GetTestArray(100, elementsMinValue: -1, elementsMaxValue: 1, exceptZeros: true);

            ProcessNums(ProductOfArrayExceptSelfCalculator.ProductExceptSelfStupid, nums, printArrays);
            ProcessNums(ProductOfArrayExceptSelfCalculator.ProductExceptSelfWithDivisor, nums, printArrays);
            ProcessNums(ProductOfArrayExceptSelfCalculator.ProductExceptSelf, nums, printArrays);

            Console.ReadLine();
        }

        delegate int[] ProductDelegate(int[] nums);

        private static void ProcessNums(ProductDelegate productDelegate, int[] nums, bool printArrays)
        {
            Stopwatch stopwatch = new Stopwatch();
            
            PrintArray(nums, printArrays);

            stopwatch.Restart();
            var product = productDelegate(nums);
            var operationTime = stopwatch.Elapsed;

            PrintArray(product, printArrays);

            Console.WriteLine(operationTime);
            Console.WriteLine();
        }

        private static void PrintArray(int[] array, bool printArrays = true)
        {
            if (printArrays == false)
                return;

            foreach (var i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}