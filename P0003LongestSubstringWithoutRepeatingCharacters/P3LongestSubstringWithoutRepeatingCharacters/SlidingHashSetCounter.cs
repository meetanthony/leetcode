namespace P3LongestSubstringWithoutRepeatingCharacters;

public class SlidingHashSetCounter : ILengthCounter
{
    public static int LengthOfLongestSubstring(string s)
    {
        HashSet<char> hashSet = new HashSet<char>();
        int max = 0;
        var left = 0;
        var right = 0;
        while (right < s.Length)
        {
            var sr = s[right];
            while (hashSet.Contains(sr))
            {
                hashSet.Remove(s[left]);
                left++;
            }
            hashSet.Add(sr);
            if (hashSet.Count > max)
                max = hashSet.Count;

            right++;
        }

        return max;
    }

    public int GetLength(string s)
    {
        return LengthOfLongestSubstring(s);
    }
}