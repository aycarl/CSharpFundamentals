using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90:
                        return 'A';
                    case var d when d >= 80:
                        return 'B';
                    case var d when d >= 70:
                        return 'C';
                    case var d when d >= 60:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
        public int Count;
        public double Sum;

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Count = 0;
        }

        public void Add(double number)
        {
            this.High = Math.Max(number, High);
            this.Low = Math.Min(number, Low);
            Sum += number;
            Count += 1;
            Console.WriteLine($"The new High is {High} and the Low is {Low}");
        }
    }
}