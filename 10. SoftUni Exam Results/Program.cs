using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static bool IsUserExist(Dictionary<string, Dictionary<string, int>> usersLanguagesPoints, string user)
        {
            bool isThere = false;
            if (usersLanguagesPoints.ContainsKey(user))
            {
                isThere = true;
            }
            return isThere;
        }
        static bool IsUserHaveThisLanguage(Dictionary<string, Dictionary<string, int>> usersLanguagesPoints, string user, string languege)
        {
            bool haveThisLanguage = false;
            foreach (var student in usersLanguagesPoints)
            {
                var currStudent = student.Key;
                if (currStudent == user)
                {
                    var currStudentInfo = student.Value;
                    foreach (var lang in currStudentInfo)
                    {
                        if (lang.Key == languege)
                        {
                            haveThisLanguage = true;
                        }
                    }
                }
            }
            return haveThisLanguage;
        }
        static Dictionary<string, Dictionary<string, int>> ChangePointsIfAreBigger(Dictionary<string, Dictionary<string, int>> usersLanguagesPoints, string user, string language, int points)
        {
            bool findIt = false;
            foreach (var student in usersLanguagesPoints)
            {
                var currStudentName = student.Key;
                if (currStudentName == user)
                {
                    var currStudentInfo = student.Value;
                    foreach (var lang in currStudentInfo)
                    {
                        if (lang.Key == language)
                        {
                            var currPoints = lang.Value;
                            if (currPoints < points)
                            {
                                usersLanguagesPoints.Remove(user);
                                Dictionary<string, int> temp = new Dictionary<string, int>();
                                temp.Add(language, points);
                                usersLanguagesPoints.Add(user, temp);
                                findIt = true;
                                break;
                            }
                        }
                    }
                }
                if (findIt == true)
                {
                    break;
                }
            }
            return usersLanguagesPoints;
        }
        static Dictionary<string, Dictionary<string, int>> RemoveUser(Dictionary<string, Dictionary<string, int>> usersLanguagesPoints, string user)
        {
            usersLanguagesPoints.Remove(user);
            return usersLanguagesPoints;
        }

        static void Main()
        {
            Dictionary<string, Dictionary<string, int>> usersLanguagesPoints = new Dictionary<string, Dictionary<string, int>>();
            SortedDictionary<string, int> langugesCounter = new SortedDictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exam finished")
                {
                    break;
                }
                string[] command = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command[1] == "banned")
                {
                    string user = command[0];
                    if (IsUserExist(usersLanguagesPoints, user))
                    {
                        RemoveUser(usersLanguagesPoints, user);
                    }
                }
                else
                {
                    string userName = command[0];
                    string userLenguage = command[1];
                    int userPoints = int.Parse(command[2]);

                    if (!IsUserExist(usersLanguagesPoints, userName))
                    {
                        Dictionary<string, int> userInfo = new Dictionary<string, int>();
                        userInfo.Add(userLenguage, userPoints);
                        usersLanguagesPoints.Add(userName, userInfo);

                        if (langugesCounter.ContainsKey(userLenguage))
                        {
                            langugesCounter[userLenguage]++;
                        }
                        else
                        {
                            langugesCounter.Add(userLenguage, 1);
                        }
                    }
                    else
                    {
                        if (IsUserHaveThisLanguage(usersLanguagesPoints, userName, userLenguage))
                        {
                            ChangePointsIfAreBigger(usersLanguagesPoints, userName, userLenguage, userPoints);
                            langugesCounter[userLenguage]++;
                        }
                        else
                        {
                            usersLanguagesPoints[userName].Add(userLenguage, userPoints);
                            langugesCounter[userLenguage]++;
                        }
                    }
                }
            }
            Console.WriteLine("Results:");
            foreach (var userInfo in usersLanguagesPoints.OrderByDescending(r => r.Value.Sum(y => y.Value)).ThenBy(j => j.Key))
            {
                string currName = userInfo.Key;
                foreach (var lang in userInfo.Value)
                {
                    int currPoints = lang.Value;
                    Console.WriteLine($"{currName} | {currPoints}");
                }
            }
            Console.WriteLine("Submissions:");
            foreach (var language in langugesCounter)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
