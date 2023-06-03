// See https://aka.ms/new-console-template for more information

var solution = new Solution();

Console.WriteLine(solution.IsPalindrome(12321));
Console.WriteLine(solution.IsPalindrome(1111));
Console.WriteLine(solution.IsPalindrome(-2112));
Console.WriteLine(solution.IsPalindrome(0));
Console.WriteLine(solution.IsPalindrome(15));
Console.WriteLine(solution.IsPalindrome(Int32.MaxValue));
Console.WriteLine(solution.IsPalindrome(Int32.MinValue));

public class Solution {
    public bool IsPalindrome(int x)
    {
        Console.WriteLine(x);
        if (x < 0)
            return false;

        int digitsNumber = 0;
        while (x>=Math.Pow(10, digitsNumber))
        {
            digitsNumber++;
        }
        
        Console.WriteLine($"digitsNumber: {digitsNumber}");

        int[] digits = new int[digitsNumber];
        for (int i = 0; i < digits.Length; i++)
        {
            var delimiter = Math.Pow(10, i);
            digits[i] = (int)((x % (delimiter*10)) /delimiter);
        }

        for (int i = 0; i < digits.Length/2; i++)
        {
            var a = digits[i];
            var b = digits[digits.Length - 1 - i];
            if (a != b)
                return false;
        }

        return true;
    }
}