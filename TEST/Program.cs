using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._ForceBook
{
    class Program
    {
        static bool IsMemberSomwhereAlreadyIn(Dictionary<string, List<string>> allForce, string member)
        {
            bool isThere = false;
            if (allForce.Any(x => x.Value.Contains(member)))
            {
                isThere = true;
            }
            return isThere;
        }
        static bool IsMemberAlredyInTheForce(Dictionary<string, List<string>> allForce, string force, string memeber)
        {
            bool isThere = false;
            if (allForce[force].Contains(memeber))
            {
                isThere = true;
            }
            return isThere;
        }
        static bool IsForceAlreadyExist(Dictionary<string, List<string>> allForce, string force)
        {
            bool isThere = false;
            if (allForce.ContainsKey(force))
            {
                isThere = true;
            }
            return isThere;
        }
        static void ChangePlayerForce(Dictionary<string, List<string>> allForce, string forceSide, string member)
        {
            foreach (var force in allForce)
            {
                if (force.Value.Contains(member))
                {
                    force.Value.Remove(member);
                    allForce[forceSide].Add(member);
                    Console.WriteLine($"{member} joins the {forceSide} side!");
                    break;
                }
            }
        }
        static void AddUniqueMember(Dictionary<string, List<string>> allForce, string forceSide, string member)
        {
            if (!allForce.Any(x => x.Value.Contains(member)))
            {
                allForce[forceSide].Add(member);
                Console.WriteLine($"{member} joins the {forceSide} side!");
            }
        }

        static void Main()
        {
            Dictionary<string, List<string>> allForce = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }

                string[] info = input.Split(" ").ToArray();

                if (info.Contains("|"))
                {
                    string[] addForce = input.Split(" | ").ToArray();
                    string forceSide = addForce[0];
                    string member = addForce[1];

                    if (!IsForceAlreadyExist(allForce, forceSide))
                    {
                        allForce.Add(forceSide, new List<string>());
                    }
                    if (!IsMemberSomwhereAlreadyIn(allForce, member))
                    {
                        allForce[forceSide].Add(member);
                    }
                }
                else if (info.Contains("->"))
                {
                    string[] moveCommand = input.Split(" -> ").ToArray();
                    string member = moveCommand[0];
                    string forceSide = moveCommand[1];
                    if (!IsForceAlreadyExist(allForce, forceSide))
                    {
                        allForce.Add(forceSide, new List<string>());
                        if (IsMemberSomwhereAlreadyIn(allForce, member))
                        {
                            ChangePlayerForce(allForce, forceSide, member);
                        }
                        else
                        {
                            AddUniqueMember(allForce, forceSide, member);
                        }
                    }
                    else
                    {
                        if (IsMemberAlredyInTheForce(allForce, forceSide, member))
                        {
                            continue;
                        }
                        if (!IsMemberSomwhereAlreadyIn(allForce, member))
                        {
                            AddUniqueMember(allForce, forceSide, member);
                        }
                        else
                        {
                            ChangePlayerForce(allForce, forceSide, member);
                        }
                    }
                }
            }
            foreach (var forceSide in allForce.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                if (forceSide.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {forceSide.Key}, Members: {forceSide.Value.Count}");
                    foreach (var memeber in forceSide.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {memeber}");
                    }
                }
            }
        }
    }
}
