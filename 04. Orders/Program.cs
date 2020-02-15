using System;
using System.Linq;
using System.Collections.Generic;

namespace TEST
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, double[]> bils = new Dictionary<string, double[]>();
            string input = Console.ReadLine();

            while (true)
            {
                if (input == "buy")
                {
                    break;
                }

                string[] item = input.Split().ToArray();
                string name = item[0];
                double price = double.Parse(item[1]);
                double quantity = double.Parse(item[2]);
                double sum = price * quantity;

                double[] itemInfo = new double[] { price, quantity, sum };

                if (!bils.ContainsKey(name))
                {
                    bils.Add(name, itemInfo);
                }
                else
                {
                    double[] refresh = new double[3];

                    refresh[1] = bils[name][1] + quantity;
                    refresh[2] = refresh[1] * price;
                    bils[name] = refresh;
                }
                input = Console.ReadLine();
            }

            foreach (var product in bils)
            {
                Console.WriteLine($"{product.Key} -> {product.Value[2]:F2}");
            }
        }
    }
}
