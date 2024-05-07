namespace P3LongestSubstringWithoutRepeatingCharacters;

public class HashSetCounter : ILengthCounter
{
    public static int LengthOfLongestSubstring(string s)
    {
        int max = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var l = LengthOfLongestSubstring(s, i);
            if (max < l)
                max = l;
        }

        return max;
    }

    public static int LengthOfLongestSubstring(string s, int start)
    {
        HashSet<char> hashSet = new HashSet<char>();
        var c = s[start];
        int count = 0;
        while (hashSet.Contains(c) == false)
        {
            hashSet.Add(c);
            count++;
            if (start + count == s.Length)
                return count;
            c = s[start + count];
        }

        return count;
    }

    public int GetLength(string s)
    {
        return LengthOfLongestSubstring(s);
    }
}