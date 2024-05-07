namespace P3LongestSubstringWithoutRepeatingCharacters;

internal class Program
{

    private static void Main(string[] args)
    {
        Test(new HashSetCounter());
        Console.WriteLine();
        Test(new DictionaryCounter());

        Console.ReadLine();
    }

    private static bool Test(ILengthCounter counter)
    {
        var result = true;
        result &= Test(counter, "abcabcbb", 3);
        result &= Test(counter, "bbbbb", 1);
        result &= Test(counter, "pwwkew", 3);
        result &= Test(counter, "", 0);

        return result;
    }

    private static bool Test(ILengthCounter counter, string testStr, int rightAnswer)
    {
        var calculatedLength = counter.GetLength(testStr);
        Console.WriteLine($"{calculatedLength} == {rightAnswer} = {calculatedLength == rightAnswer}");

        return rightAnswer == calculatedLength;
    }
}