using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set;}
    }

    //an interface does not have any member implementations
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        String Name { get;}
        event GradeAddedDelegate GradeAdded;
    }

    //abstract class BookBase inherits from NamedObject class
    //a class can implement several interfaces unlike an abstract class
    //Book class implements IBook interface
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    // a book class that read and writes into a file
    public class DiskBook : Book
    {
        public DiskBook(String name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            //open a file that has the name name of the book
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                //add a new line in the file that contains the grade value
                writer.WriteLine(grade);
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    Console.WriteLine($"{number} was read from the {Name}.txt file");
                    result.Add(number);
                    line = reader.ReadLine();
                } ;
            }
            return result;
        }
        
        public List<double> grades;

    }

    //a class can only inherit from one other class
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            Name = name;
            grades = new List<double>();
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

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for(var index = 0; index < grades.Count; index++)
            {
                result.Add(grades[index]);
            }
            
            return result;
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalide {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public List<double> grades;

    }
}