using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    internal class TodoService
    {
        private readonly TodoStorage storage;

        public TodoService(TodoStorage storage)
        {
            this.storage = storage;
        }

        public IReadOnlyList<TodoItem> GetAll()
        {
            return storage.Todos;
        }

        public TodoItem FindById(int id)
        {
            foreach(TodoItem taskItem in storage.Todos)
            {
                return taskItem;
            }

            return null;
        }

        public void Add(string title, string description, DateTime dueDate)
        {
            TodoItem taskItem = new TodoItem(storage.NextId, title, description, dueDate);
            storage.Todos.Add(taskItem);
            storage.NextId++;

        }

        public void Completed(int id)
        {
            TodoItem todos = FindById(id);
            if(todos == null)
            {
                throw new ArgumentException("Няма въведени задачи.");
            }

            todos.Completed();

        }

        public void Deleted(int id)
        {
            TodoItem task = FindById(id);
            if (task == null)
            {
                throw new ArgumentException("Няма въведени задачи.");
            }

           storage.Todos.Remove(task);

        }

        

    }
}
