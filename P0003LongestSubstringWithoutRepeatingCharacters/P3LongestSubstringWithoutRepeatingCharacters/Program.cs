using Common.TestData;
using System.Text;

namespace P3LongestSubstringWithoutRepeatingCharacters;

internal class Program
{
    private static void Main(string[] args)
    {
        var brutforceArrays = new BrutforceArrays<char>(10, 'a', 'd');
        var casesCount = brutforceArrays.CasesCount;
        Console.WriteLine($"brutforce cases: {casesCount}");

        var stopUi = false;

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

            var hashLength = hashCounter.GetLength(str);
            var dictLength = dictCounter.GetLength(str);
            if (hashLength != dictLength)
                throw new Exception(str);

            arraysCounter++;
        }

        stopUi = true;

        Console.ReadLine();
    }
}