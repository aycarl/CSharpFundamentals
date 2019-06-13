using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            Name = name;
            this.grades = new List<double>();
        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public Statistics GetStatistics()
        {

            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for(var index = 0; index < grades.Count; index++)
            {
                // if (grades[index] > 42.1){
                //     Console.WriteLine("Just a temp done statement.");
                // }


                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];
            }
            
            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when d >=90:
                    result.Letter = 'A';
                    break;
                case var d when d >=80:
                    result.Letter = 'B';
                    break;
                case var d when d >=70:
                    result.Letter = 'C';
                    break;
                case var d when d >=60:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalide {nameof(grade)}");
            }
        }
        public List<double> grades;

        //name property can be publicly retrived but only privately edited
        public string Name { get; private set;}


    }
}