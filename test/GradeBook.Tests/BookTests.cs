using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        //test check is the grade entered is within the given range of grades
        [Fact]
        public void BookGradesAreWithinRange()
        {
            var book = new Book("");
            book.AddGrade(100.0);
            Assert.Contains(100.0, book.grades);
        }
        
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange section
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act section
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal('B',result.Letter);
        }
    }
}
