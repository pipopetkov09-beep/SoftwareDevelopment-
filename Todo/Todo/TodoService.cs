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
        private readonly List<TaskItem> tasks = new List<TaskItem>();
        private int nextId = 1;

        public List<TaskItem> GetAll()
        {
            return tasks;
        }

        public TaskItem FindById(int id)
        {
            foreach(TaskItem taskItem in tasks)
            {
                return taskItem;
            }

            return null;
        }

        public void Add(string title, string description, DateTime dueDate)
        {
            TaskItem taskItem = new TaskItem(nextId, title, description, dueDate);
            tasks.Add(taskItem);
            nextId++;

        }

        public void Completed(int id)
        {
            TaskItem task = FindById(id);
            if(task == null)
            {
                throw new ArgumentException("Няма въведени задачи.");
            }

            task.Completed();

        }

    }
}
