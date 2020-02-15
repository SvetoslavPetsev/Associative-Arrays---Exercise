using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main()
        {
            SortedDictionary<string, int> itemsAndCount = new SortedDictionary<string, int>();
            bool haveLegendary = false;
            while (!haveLegendary)
            {
                string[] inputInfo = Console.ReadLine().Split().ToArray();

                for (int i = 0; i < inputInfo.Length - 1; i += 2)
                {
                    int count = int.Parse(inputInfo[i]);
                    string material = inputInfo[i + 1].ToLower();

                    if (!itemsAndCount.ContainsKey(material))
                    {
                        itemsAndCount.Add(material, count);
                    }
                    else
                    {
                        itemsAndCount[material] += count;
                    }

                    if (itemsAndCount.ContainsKey("shards") && itemsAndCount["shards"] >= 250)
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                        itemsAndCount["shards"] -= 250;
                        haveLegendary = true;
                        break;
                    }
                    else if (itemsAndCount.ContainsKey("fragments") && itemsAndCount["fragments"] >= 250)
                    {
                        Console.WriteLine("Valanyr obtained!");
                        itemsAndCount["fragments"] -= 250;
                        haveLegendary = true;
                        break;
                    }
                    else if (itemsAndCount.ContainsKey("motes") && itemsAndCount["motes"] >= 250)
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        itemsAndCount["motes"] -= 250;
                        haveLegendary = true;
                        break;
                    }
                }
            }
            SortedDictionary<string, int> legendaryItems = new SortedDictionary<string, int>();
           
            legendaryItems["shards"] = 0;
            legendaryItems["motes"] = 0;
            legendaryItems["fragments"] = 0;
            
            foreach (var someItem in itemsAndCount)
            {
                if (someItem.Key == "shards" || someItem.Key == "motes" || someItem.Key == "fragments")
                {
                    legendaryItems[someItem.Key] += someItem.Value;  
                }
            }
            if (itemsAndCount.ContainsKey("shards"))
            {
                itemsAndCount.Remove("shards");
            }
            if (itemsAndCount.ContainsKey("motes"))
            {
                itemsAndCount.Remove("motes");
            }
            if (itemsAndCount.ContainsKey("fragments"))
            {
                itemsAndCount.Remove("fragments");
            }

            Dictionary<string, int> sortedLegendary = new Dictionary<string, int>(legendaryItems.OrderByDescending(x => x.Value).ThenBy(x => x.Key));

            foreach (var legendary in sortedLegendary)
            {
                Console.WriteLine(string.Join(Environment.NewLine, legendary.Key + ": " + legendary.Value));
            }
            foreach (var someItem in itemsAndCount)
            {
                Console.WriteLine(string.Join(Environment.NewLine, someItem.Key + ": " + someItem.Value));
            }
        }
    }
}
