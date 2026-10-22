using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    internal class Student
    {
        private int id;
        private string name;
        private int age;
        private int grade;
        private double averageScore;
        private decimal fee;
        private char classLetter;
        private DateTime birthDate;

        public int Id
        {
            get { return id; }

        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Името не може да бъде празно или само интервали.",
                        nameof(Name));
                }

                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 6 || value > 20)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(Age),
                        "Възрастта трябва да бъде между 6 и 20 години.");
                }

                age = value;
            }
        }

        public int Grade
        {
            get { return grade; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(Grade),
                        "Класът трябва да бъде между 1 и 12.");
                }

                grade = value;
            }
        }

        public double AverageScore
        {
            get { return averageScore; }
            set
            {
                if (double.IsNaN(value) ||
                    double.IsInfinity(value) ||
                    value < 2.00 || value > 6.00)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(AverageScore),
                        "Средният успех трябва да бъде между 2.00 и 6.00.");
                }

                averageScore = value;
            }
        }

        public decimal Fee
        {
            get { return fee; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(Fee),
                        "Таксата не може да бъде отрицателна.");
                }

                fee = value;
            }
        }

        public bool HasScholarship { get; set; }

        public char ClassLetter
        {
            get { return classLetter; }
            set
            {
                if (!char.IsLetter(value))
                {
                    throw new ArgumentException(
                        "Паралелката трябва да бъде буква.",
                        nameof(ClassLetter));
                }

                classLetter = value;
            }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                if (value.Date > DateTime.Today)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(BirthDate),
                        "Датата на раждане не може да бъде в бъдещето.");
                }

                birthDate = value;
            }
        }

        public Student(int id, string name)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(id),
                    "Идентификаторът трябва да бъде положително число.");
            }

            this.id = id;
            Name = name;
        }
    }
}
