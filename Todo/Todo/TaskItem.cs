using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    internal class TaskItem
    {

        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(int id, string title, string description, DateTime deadline)
        {
            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id трябва да е положително.");
            }
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("Заглавието е задължително.");
            }

            Id = Id; 
            Title = title;
            Description = description;
            Deadline = deadline;
            IsCompleted = false;
        }
    }
}
