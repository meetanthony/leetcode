using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P58LengthOfLastWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LengthOfLastWord("   fly me   to   the moon  "));

            Console.ReadLine();
        }

        public static int LengthOfLastWord(string s)
        {
            var splits = s.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            return splits[splits.Length - 1].Length;
        }
    }
}
