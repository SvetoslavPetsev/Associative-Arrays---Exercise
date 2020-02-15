using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Courses
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> courseAndStudents = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string[] info = input.Split(" : ").ToArray();

                string course = info[0];
                string studentName = info[1];

                if (!courseAndStudents.ContainsKey(course))
                {
                    List<string> students = new List<string>();
                    students.Add(studentName);
                    courseAndStudents.Add(course, students);
                }
                else
                {
                    courseAndStudents[course].Add(studentName);
                }

            }

            foreach (var course in courseAndStudents.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
