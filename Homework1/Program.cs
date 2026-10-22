using System.Globalization;

namespace Homework1
{
    internal class Program
    {
        private static int nextId = 1;

        private static readonly CultureInfo BgCulture =
            CultureInfo.GetCultureInfo("bg-BG");

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== РЕГИСТРАЦИЯ НА УЧЕНИК ===");

            Student student = null;

            while (student == null)
            {
                try
                {
                    string name = ReadName();
                    student = new Student(nextId, name);

                    student.Age = ReadInt(
                        "Възраст: ", "Age", student);

                    student.Grade = ReadInt(
                        "Клас: ", "Grade", student);

                    student.AverageScore = ReadDouble(
                        "Среден успех: ", student);

                    student.Fee = ReadDecimal(
                        "Такса: ", student);

                    student.HasScholarship = ReadBool(
                        "Получава ли стипендия? (да/не): ");

                    student.ClassLetter = ReadChar(
                        "Паралелка: ", student);

                    student.BirthDate = ReadDate(
                        "Дата на раждане (дд.ММ.гггг): ",
                        student);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(
                        $"Грешка: {ex.Message}");
                    Console.WriteLine(
                        "Моля, въведете данните отново.\n");

                    student = null;
                }
            }

            nextId++;

            Console.WriteLine("\n=== ДАННИ ЗА УЧЕНИК ===\n");
            Console.WriteLine($"Id: {student.Id}");
            Console.WriteLine($"Име: {student.Name}");
            Console.WriteLine($"Възраст: {student.Age}");
            Console.WriteLine($"Клас: {student.Grade}");
            Console.WriteLine(
                $"Среден успех: {student.AverageScore:F2}");
            Console.WriteLine(
                $"Такса: {student.Fee:F2} лв.");
            Console.WriteLine(
                $"Стипендия: {(student.HasScholarship ? "Да" : "Не")}");
            Console.WriteLine($"Паралелка: {student.ClassLetter}");
            Console.WriteLine(
                $"Дата на раждане: {student.BirthDate:dd.MM.yyyy}");
        }

        private static string ReadName()
        {
            while (true)
            {
                Console.Write("Име: ");
                string input = Console.ReadLine();

                try
                {
                    // Валидацията се извършва в Student.
                    Student test = new Student(1, input);
                    return test.Name;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Грешка: {ex.Message}");
                }
            }
        }

        private static int ReadInt(
            string prompt, string property, Student student)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int value))
                {
                    Console.WriteLine(
                        "Невалиден формат. Въведете цяло число.");
                    continue;
                }

                try
                {
                    if (property == "Age")
                        student.Age = value;
                    else
                        student.Grade = value;

                    return value;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Грешка: {ex.Message}");
                }
            }
        }

        private static double ReadDouble(string prompt, Student student)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!double.TryParse(
                    input,
                    NumberStyles.Float,
                    BgCulture,
                    out double value))
                {
                    // Позволява и десетична точка.
                    if (!double.TryParse(
                        input,
                        NumberStyles.Float,
                        CultureInfo.InvariantCulture,
                        out value))
                    {
                        Console.WriteLine(
                            "Невалиден формат. Въведете число.");
                        continue;
                    }
                }

                try
                {
                    student.AverageScore = value;
                    return value;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Грешка: {ex.Message}");
                }
            }
        }

        private static decimal ReadDecimal(string prompt, Student student)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!decimal.TryParse(
                    input,
                    NumberStyles.Number,
                    BgCulture,
                    out decimal value))
                {
                    if (!decimal.TryParse(
                        input,
                        NumberStyles.Number,
                        CultureInfo.InvariantCulture,
                        out value))
                    {
                        Console.WriteLine(
                            "Невалиден формат. Въведете сума.");
                        continue;
                    }
                }

                try
                {
                    student.Fee = value;
                    return value;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Грешка: {ex.Message}");
                }
            }
        }

        private static bool ReadBool(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim().ToLower();

                if (input == "да" || input == "д" || input == "yes")
                    return true;

                if (input == "не" || input == "н" || input == "no")
                    return false;

                Console.WriteLine("Моля, въведете „да“ или „не“.");
            }
        }

        private static char ReadChar(string prompt, Student student)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) ||
                    input.Trim().Length != 1)
                {
                    Console.WriteLine(
                        "Въведете точно една буква.");
                    continue;
                }

                try
                {
                    char value = input.Trim()[0];
                    student.ClassLetter = value;
                    return value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Грешка: {ex.Message}");
                }
            }
        }

        private static DateTime ReadDate(
            string prompt, Student student)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!DateTime.TryParseExact(
                    input,
                    "dd.MM.yyyy",
                    BgCulture,
                    DateTimeStyles.None,
                    out DateTime value))
                {
                    Console.WriteLine(
                        "Невалидна дата. Използвайте формат дд.ММ.гггг.");
                    continue;
                }

                try
                {
                    student.BirthDate = value;
                    return value;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Грешка: {ex.Message}");
                }
            }
        }
    }
}
