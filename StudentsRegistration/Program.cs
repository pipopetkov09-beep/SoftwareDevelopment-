using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsRegistration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете име:");
            string name = Console.ReadLine();



            Console.WriteLine("Въведете възраст:");
            if(int.TryParse(Console.ReadLine(),out int age))
            {
                Console.WriteLine($"Възраст: {age}");
            }
            else
            {
                Console.WriteLine("Невалидна възраст.");
            }



            Console.WriteLine("Въведете клас на ученика:");
           
            if(byte.TryParse(Console.ReadLine(), out byte c))
            {
                Console.WriteLine($"Клас на ученика: {c}");
            }
            else
            {
                Console.WriteLine("Нeвалидна klas.");
            }


            Console.WriteLine("Въвдете среден успех:");
            if(double.TryParse(Console.ReadLine(), out double AverageGrade))
            {
                Console.WriteLine($"Въведете среден успех: {AverageGrade}");
            }
            else
            {
                Console.WriteLine("Невалиден успех.");
            }


            Console.WriteLine("Въведете такса:");
            if(decimal.TryParse(Console.ReadLine(), out decimal tax))
            {
                Console.WriteLine($"Таксата е: {tax}");
            }
            else
            {
                Console.WriteLine("Невалидна такса.");
            }


            Console.WriteLine("Въведете стипендия:");
            if(bool.TryParse(Console.ReadLine(), out bool hasSchoolarship))
            {
                Console.WriteLine($"Gets Schoolarship: {hasSchoolarship}");
            }
            else
            {
                Console.WriteLine("Doesn't get.");
            }


            Console.WriteLine("Въведете буква на паралелката:");
            if(char.TryParse(Console.ReadLine(), out char ch))
            {
                Console.WriteLine($"Буквата на паралелката е: {ch}");
            }
            else
            {
                Console.WriteLine("Невалидна.");
            }

            Console.WriteLine("Date of Birth is:");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
            {
                Console.WriteLine($"Дата: {birthDate:d}");
            }
            else
            {
                Console.WriteLine("Невалидна дата.");
            }


            while (true)
            {
                Console.Write("Дата на раждане:");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }

                Console.WriteLine("Невалидна дата. Опитайте отново.");
            }

        }
    }
}
