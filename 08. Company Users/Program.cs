using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Company_Users
{
    class Program
    {
        static void Main()
        {
            SortedDictionary<string, List<string>> companyList = new SortedDictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] info = input.Split(" -> ").ToArray();
                string companyName = info[0];
                string employeeID = info[1];

                if (!companyList.ContainsKey(companyName))
                {
                    companyList.Add(companyName, new List<string>() { employeeID });
                }
                else if (!companyList.Any(x => x.Value.Contains(employeeID)))
                {
                    companyList[companyName].Add(employeeID);
                }
            }
            foreach (var company in companyList)
            {
                Console.WriteLine(company.Key);
                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
