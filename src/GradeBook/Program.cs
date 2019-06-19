using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Carl's Grade Book");
            book.GradeAdded += OnGradeAdded;


            System.Console.WriteLine($"Welcome to {book.Name}");

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named: {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        private static void EnterGrades(IBook book)
        {
            var enteredGrade = "";
            var grade = 0.0;
            do
            {
                System.Console.WriteLine("Please enter a grade between 100 and q to quit:");
                if (grade < 0)
                {
                    break;
                }
                try
                {
                    enteredGrade = Console.ReadLine();
                    if (enteredGrade == "q")
                    {
                        break;
                    }
                    grade = double.Parse(enteredGrade);
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

            } while (true);
        }

        //an event handler that displays text when an event occursin the add grade method of a book
        static void OnGradeAdded(object sender, EventArgs arge)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
