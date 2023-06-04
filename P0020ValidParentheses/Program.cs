// See https://aka.ms/new-console-template for more information

var solution = new Solution();
Console.WriteLine(solution.IsValid("()"));
Console.WriteLine(solution.IsValid("()[]{}"));
Console.WriteLine(solution.IsValid("([{}])"));
Console.WriteLine(solution.IsValid("()}"));
Console.WriteLine(solution.IsValid("()))"));

public class Solution {
    private readonly Dictionary<char, char> _parentheses = new Dictionary<char, char>(3);
    
    public Solution()
    {
        _parentheses[')'] = '(';
        _parentheses[']'] = '[';
        _parentheses['}'] = '{';
    }
    public bool IsValid(string s)
    {
        if (s.Length % 2 == 1)
            return false;

        var chars = s.ToCharArray();

        var opens = new Stack<char>(chars.Length/2);

        for (int i = 0; i < chars.Length; i++)
        {
            var c = chars[i];
            if (_parentheses.TryGetValue(c, out var parenthesis))
            {
                if (opens.Count == 0)
                    return false;
                var o = opens.Pop();
                if (o != parenthesis)
                    return false;
            }
            else
            {
                opens.Push(c);
            }
        }

        return opens.Count == 0;
    }
}