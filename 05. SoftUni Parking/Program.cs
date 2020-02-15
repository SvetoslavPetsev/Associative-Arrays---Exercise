using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, string> usersAndCarNumbers = new Dictionary<string, string>();

            int countOfTryToParking = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfTryToParking; i++)
            {
                List<string> input = Console.ReadLine().Split().ToList();

                if (input[0] == "register")
                {
                    string userName = input[1];
                    string carNumber = input[2];

                    if (!usersAndCarNumbers.ContainsKey(userName))
                    {
                        usersAndCarNumbers.Add(userName, carNumber);
                        Console.WriteLine($"{userName} registered {carNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {carNumber}");
                    }
                }
                else if (input[0] == "unregister")
                {
                    string userName = input[1];

                    if (usersAndCarNumbers.ContainsKey(userName))
                    {
                        usersAndCarNumbers.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                }
            }
            foreach (var user in usersAndCarNumbers)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
