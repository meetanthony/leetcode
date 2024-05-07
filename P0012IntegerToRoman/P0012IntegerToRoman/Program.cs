// See https://aka.ms/new-console-template for more information

var solution = new Solution();

for (int i = 0; i < 4000; i++)
{
    var str = solution.IntToRoman(i);
    var ii = solution.RomanToInt(str);
    Console.WriteLine($"{ii} == {str}");
    if (i != ii)
        throw new Exception();
}

Console.ReadLine();

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

    public string IntToRoman(int num)
    {
        var str = string.Empty;
        if (num > 0)
            str = GetStr(num % 10, new[] { "I", "V", "X" });
        if (num > 9)
            str = GetStr((num / 10) % 10, new[] { "X", "L", "C" }) + str;
        if (num > 99)
            str = GetStr((num / 100) % 10, new[] { "C", "D", "M" }) + str;
        if (num > 999)
            for (int i = 0; i < num/1000; i++)
            {
                str = "M" + str;
            }

        return str;
    }

    private string GetStr(int num, string[] c)
    {
        switch (num)
        {
            case 0:
                return string.Empty;
            case 1:
                return c[0];
            case 2:
                return c[0] + c[0];
            case 3:
                return c[0] + c[0] + c[0];
            case 4:
                return c[0] + c[1];
            case 5:
                return c[1];
            case 6:
                return c[1] + c[0];
            case 7:
                return c[1] + c[0] + c[0];
            case 8:
                return c[1] + c[0] + c[0] + c[0];
            case 9:
                return c[0] + c[2];
            case 10:
                return c[2];
            default:
                throw new Exception();
        }
    }
}