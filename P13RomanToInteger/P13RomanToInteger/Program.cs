// See https://aka.ms/new-console-template for more information

var solution = new Solution();

Console.WriteLine($"III = {solution.RomanToInt("III")}");
Console.WriteLine($"LVIII = {solution.RomanToInt("LVIII")}");
Console.WriteLine($"MCMXCIV = {solution.RomanToInt("MCMXCIV")}");

public class Solution {
    public int RomanToInt(string s)
    {
        Dictionary<char, int> romansToInts = new Dictionary<char, int>(7);
        romansToInts['I'] = 1;
        romansToInts['V'] = 5;
        romansToInts['X'] = 10;
        romansToInts['L'] = 50;
        romansToInts['C'] = 100;
        romansToInts['D'] = 500;
        romansToInts['M'] = 1000;

        int max = 0;
        int accum = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            var c = s[i];
            var current = romansToInts[c];
            if (current >= max)
            {
                accum += current;
                max = current;
            }
            else
            {
                accum -= current;
            }
        }

        return accum;
    }
}