using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<double>> nameAndGrade = new Dictionary<string, List<double>>();
            int numberInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberInput; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!nameAndGrade.ContainsKey(name))
                {
                    nameAndGrade.Add(name, new List<double>() { grade });
                }
                else
                {
                    nameAndGrade[name].Add(grade);
                }
            }

            Dictionary<string, double> studentSuccess = new Dictionary<string, double>();

            foreach (var student in nameAndGrade.Where(x => x.Value.Average() >= 4.50))
            {
                studentSuccess.Add(student.Key, student.Value.Average());
            }

            foreach (var student in studentSuccess.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{student.Key} -> {student.Value:F2}");
            }
        }
    }
}
