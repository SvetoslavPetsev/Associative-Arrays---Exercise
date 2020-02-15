using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            while (true)
            {
                string input = Console.ReadLine();
               
                if (input == "stop")
                {
                    break;
                }

                int count = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(input))
                {
                    resources.Add(input, count);
                }
                else
                {
                    resources[input] += count;
                }
            }
            foreach (var resource in resources)
            {
                Console.WriteLine(string.Join(Environment.NewLine, resource.Key + " -> " + resource.Value));
            }
        }
    }
}
