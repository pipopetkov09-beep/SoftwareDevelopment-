using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    internal class Program
    {
        
        
        static void Main()
        {
            //TodoStorage storage = new TodoStorage();
            FileStorage fileStorage = new FileStorage("todos.json");
            TodoService service = new TodoService(fileStorage);

            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine("===== УПРАВЛЕНИЕ НА ЗАДАЧИ =====");
                Console.WriteLine("1. Добави нова задача");
                Console.WriteLine("2. Покажи всички задачи");
                Console.WriteLine("3. Маркирай задача като изпълнена");
                Console.WriteLine("4. Изтрий задача");
                Console.WriteLine("5. Изход");
                Console.WriteLine("===============================");
                Console.Write("Изберете опция: ");

                string choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddTodo(service);
                            break;

                        case "2":
                            ShowTodos(service);
                            break;

                        case "3":
                            CompleteTodo(service);
                            break;

                        case "4":
                            DeletedTodo(service);
                            break;

                        case "5":
                            running = false;
                            Console.WriteLine("Програмата приключи.");
                            break;

                        default:
                            Console.WriteLine("Невалиден избор!");
                            Pause();
                            break;
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }

        static void AddTodo(TodoService service)
        {
            Console.Clear();
            Console.WriteLine("===== ДОБАВЯНЕ НА ЗАДАЧА =====");
            

            Console.Write("Заглавие: ");
            string title = Console.ReadLine();
            

            Console.Write("Описание: ");
            string description = Console.ReadLine();
            

            DateTime deadline;

            while (true)
            {
                Console.Write("Краен срок (дд.ММ.гггг): ");

                if (DateTime.TryParse(Console.ReadLine(), out deadline))
                {
                    break;
                }

                Console.WriteLine("Невалидна дата! Опитайте отново.");
            }

            service.Add(title, description, deadline);

            Console.WriteLine("\nЗадачата беше добавена успешно!");
            Pause();

        }

        static void ShowTodos(TodoService service)
        {
            Console.Clear();
            Console.WriteLine("===== ВСИЧКИ ЗАДАЧИ =====");

            var todos = service.GetAll();

            if (todos.Count == 0)
            {
                Console.WriteLine("Няма въведени задачи.");
                Pause();
                return;
            }

            else
            {
                foreach(TodoItem todoItem in todos)
                {
                    Console.WriteLine($"{todoItem}");
                }
            }

                Pause();
        }

        private static void CompleteTodo(TodoService service)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("=====  Маркирай задача като завършена =======\n");
            ShowTodos(service);

            Console.Write("Избери Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Невалидно id.");
                Console.Write("Избери Id: ");
            }

            service.Completed(id);

            Console.WriteLine("Задачата е завършена.");

        }

        private static void DeletedTodo(TodoService service)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("=====  Изтрий задача =======\n");
            ShowTodos(service);

            Console.Write("Избери Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Невалидно id.");
                Console.Write("Избери Id: ");
            }

            service.Deleted(id);

            Console.WriteLine("Задачата е изтрита.");

        }


        static void Pause()
        {
            Console.WriteLine("\nНатиснете Enter за продължаване...");
            Console.ReadLine();
        }


         
    }
}
