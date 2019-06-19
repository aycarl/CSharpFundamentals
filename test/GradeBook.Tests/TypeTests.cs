using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);


    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = returnMessage;
            log += returnMessage;
            log += returnMessageToLower;
            var result = log("Hello!");
            
            Assert.Equal(3, count);
        }

        string returnMessageToLower(string logMessage)
        {
            count++;
            return logMessage.ToLower();
        }

        string returnMessage(string logMessage)
        {
            count++;
            return logMessage;
        }



        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Carl";
            var upper = MakeUpperCase(name);

            Assert.Equal("CARL", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }


        //creating a test to prove that cSharp always passes by value
        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
        //Given
            var x = GetInt();
            //passing a parameter by reference
            SetInt(ref x);
        //Then
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            //Given
            var book1 = GetBook("Book 1");

            //When
            GetBookSetName(ref book1, "New Name");
            
            //Then
            Assert.Equal("New Name", book1.Name);

        }

        //this test method creates a book object, & changes the name property to "New Name" & test whether the name change was successful
        [Fact]
        public void CSharpIsPassByValue()
        {
            //Given
            var book1 = GetBook("Book 1");

            //When
            GetBookSetName(book1, "New Name");
            
            //Then
            Assert.Equal("Book 1", book1.Name);

        }

        //this test method creates a book object, & changes the name property to "New Name" & test whether the name change was successful
        [Fact]
        public void CanSetNameFromReference()
        {
            //Given
            var book1 = GetBook("Book 1");

            //When
            setName(book1, "New Name");
            
            //Then
            Assert.Equal("New Name", book1.Name);

        }
        
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange section
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            

            // act section
            

            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        // this test arranges two book instances, creates book1 with name "Book 1" and assigns the reference to book1 to a new variable book 2
        // The test compares the values (reference addresses) of the two variables, book1 and book2
        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            //arrange section
            var book1 = GetBook("Book 1");
            var book2 = book1;
            

            // act section
            

            // assert: this check whether the value held in variables book1 and book2 are the same reference addresses
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        // method creates and returns a new Book instance and assings it a name from with the parameter "name"
        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

        // method takes in a book object and a string and changes the name property of the book object to that of the provided string parameter
        private void setName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        //takes a book object & updates this book refence with a new book object with a name
        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        //takes a reference to a book & updates this book refence with a new book object with a name
        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
    }
}
