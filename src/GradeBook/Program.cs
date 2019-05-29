using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Carl's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(98.1);
            book.AddGrade(50.4);
            book.AddGrade(77.5);
            book.ShowStatistics();
           
        }
    }
}
