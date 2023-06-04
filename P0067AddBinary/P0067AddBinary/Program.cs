using System;

namespace P0067AddBinary
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(AddBinary("111", "100"));
            Console.WriteLine(AddBinary("01010101010101", "1111111111111111"));
            Console.WriteLine(AddBinary("11", "1111111111111111"));
            Console.WriteLine(AddBinary(
                "10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101",
                "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011"));

            Console.ReadLine();
        }

        public static string AddBinary(string a, string b)
        {
            string s1;
            string s2;
            if (a.Length > b.Length)
            {
                s1 = a;
                s2 = b;
            }
            else
            {
                s1 = b;
                s2 = a;
            }
            var result = string.Empty;
            var up = false;
            for (int i = 0; i < s1.Length; i++)
            {
                int bit1 = s1[s1.Length - 1 - i] == '1' ? 1 : 0;
                int bit2 = 0;
                if (s2.Length > i)
                {
                    bit2 = s2[s2.Length - 1 - i] == '1' ? 1 : 0;
                }
                int sum = bit1 + bit2;
                if (up)
                {
                    sum++;
                }

                result = (sum % 2 == 1 ? "1" : "0") + result;
                up = sum > 1;
            }

            if (up)
            {
                result = "1" + result;
            }

            return result;
        }
    }
}