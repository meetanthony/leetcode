using Common.TestData;

namespace P3LongestSubstringWithoutRepeatingCharacters;

internal class Program
{
    private static void Main(string[] args)
    {
        var brutforceArrays = new BruteForceArrays<char>(8, 'a', 'h');
        var casesCount = brutforceArrays.CasesCount;
        Console.WriteLine($"brutforce cases: {casesCount}");

        var stopUi = false;

        var slidingHashCounter = new SlidingHashSetCounter();
        var hashCounter = new HashSetCounter();
        var dictCounter = new DictionaryCounter();

        long arraysCounter = 0;

        Task.Run(() =>
        {
            while (stopUi == false)
            {
                Thread.Sleep(500);
                Console.SetCursorPosition(0, 1);
                Console.Write($"{arraysCounter} / {casesCount}");
            }

            Console.WriteLine();
            Console.WriteLine("Test is completed. Press Enter");
        });

        foreach (var array in brutforceArrays)
        {
            var str = new string(array);
            var slidingHashLength = slidingHashCounter.GetLength(str);
            var hashLength = hashCounter.GetLength(str);
            var dictLength = dictCounter.GetLength(str);
            if (hashLength != dictLength || dictLength != slidingHashLength)
                throw new Exception(str);

            arraysCounter++;
        }

        stopUi = true;

        Console.ReadLine();
    }
}