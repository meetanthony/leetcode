﻿namespace P3LongestSubstringWithoutRepeatingCharacters;

public class DictionaryCounter : ILengthCounter
{
    public static int LengthOfLongestSubstring(string str)
    {
        Dictionary<char, int> d = new Dictionary<char, int>();

        var max = 0;
        var counter = 0;
        for (var i = 0; i < str.Length; i++)
        {
            var s = str[i];
            
            if (d.TryGetValue(s, out var oldIndex))
            {
                var length = i - oldIndex;
                if (length <= counter)
                    counter = length;
                else
                    counter++;
                d[s] = i;
            }
            else
            {
                d.Add(s, i);
                counter++;
            }

            if (counter > max)
                max = counter;
        }

        return max;
    }

    public int GetLength(string s)
    {
        return LengthOfLongestSubstring(s);
    }
}