using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            this.name = name;
            this.grades = new List<double>();
        }

        public void ShowStatistics()
        {
             
            //create a generic list that functions like a regular list array
            // var grades = new List<double>(){12.7, 10.7, 6.4, 4.1};
            // grades.Add(12.5);

            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            foreach(double number in grades)
            {
                if (number > highGrade)
                {
                    highGrade = number;
                }
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }

            Console.WriteLine(result);
            Console.WriteLine($"The average grade is {result/grades.Count:N1}");
            Console.WriteLine($"The lowest grade is {lowGrade}.");
            Console.WriteLine($"The highest grade is {highGrade}.");
            Console.WriteLine($"The number of items in the grades list is {grades.Count}");

        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        private string name;
        private List<double> grades;


    }
}