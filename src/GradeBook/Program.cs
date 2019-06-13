using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Carl's Grade Book");
            System.Console.WriteLine($"Welcome to {book.Name}");
        
            var grade = 0.0;
            do 
            {
                System.Console.WriteLine("Please enter a grade between 100 and 0 AND -1 to end:");
                if (grade < 0)
                {
                    break;
                }
                try
                {
                    grade = double.Parse(Console.ReadLine());
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            } while (grade != -1);
            
            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named: {book.Name}")
            Console.WriteLine($"The lowest grade is {stats.Low}.");
            Console.WriteLine($"The highest grade is {stats.High}.");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
           
        }
    }
}
