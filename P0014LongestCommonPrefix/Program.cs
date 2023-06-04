// See https://aka.ms/new-console-template for more information

var solution = new Solution();
var strs = new[] { "flower", "flow", "flight" };
Console.WriteLine(solution.LongestCommonPrefix(strs));
strs = new[] { "dog","racecar","car" };
Console.WriteLine(solution.LongestCommonPrefix(strs));
strs = new[] { "dog","","car" };
Console.WriteLine(solution.LongestCommonPrefix(strs));
strs = new[] { null,"","car" };
Console.WriteLine(solution.LongestCommonPrefix(strs));
strs = null;
Console.WriteLine(solution.LongestCommonPrefix(strs));
strs = new []{"c", "acc"};
Console.WriteLine(solution.LongestCommonPrefix(strs));

public class Solution {
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0)
            return "";
        var prefix = strs[0];
        if (string.IsNullOrWhiteSpace(prefix))
            return "";
        
        for (int i = 1; i < strs.Length; i++)
        {
            var current = strs[i];
            if (string.IsNullOrWhiteSpace(current))
                return "";

            while (current.IndexOf(prefix) != 0)
            {
                prefix = prefix.Remove(prefix.Length - 1);
                if (prefix.Length == 0)
                    return "";
            }
        }

        return prefix;
    }
}