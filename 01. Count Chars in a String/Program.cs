using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main()
        {
            string someText = Console.ReadLine();

            char[] sorted = someText.Where(x => x != ' ').ToArray();
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char simbol in sorted)
            {
                if (!charCount.ContainsKey(simbol))
                {
                    charCount.Add(simbol, 1);
                }
                else
                {
                    charCount[simbol] += 1;
                }
            }
            foreach (var symbol in charCount)
            {
                Console.WriteLine($"{symbol.Key} -> {symbol.Value}");
            }
        }
    }
}
