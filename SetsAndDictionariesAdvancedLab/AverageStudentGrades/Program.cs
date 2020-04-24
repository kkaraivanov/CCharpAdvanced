using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int countInput = int.Parse(Console.ReadLine());
            var colection = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < countInput; i++)
            {
                var input = consoleReadline;
                string student = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!colection.ContainsKey(student))
                {
                    colection[student] = new List<decimal>();
                }

                colection[student].Add(grade);
            }

            foreach (var (student, grades) in colection)
            {
                var studentGrades = string.Join(" ", grades.Select(x => x.ToString("f2")));
                Console.WriteLine($"{student} -> {studentGrades} (avg: {grades.Average():f2})");
            }
        }

        static string[] consoleReadline
            => Console.ReadLine()
                .Split()
                .ToArray();
    }
}
