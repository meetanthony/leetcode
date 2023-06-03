using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P28FindTheIndexOfTheFirstOccurrenceInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StrStr(haystack : "sadbutsad", needle : "sad"));
            Console.ReadLine();
        }

        public static int StrStr(string haystack, string needle)
        {
            if (haystack.Length < needle.Length)
                return -1;
            return haystack.IndexOf(needle);
        }
    }
}
