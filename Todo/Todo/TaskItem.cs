using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    internal class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(string title, string description, DateTime deadline)
        {
            Title = title;
            Description = description;
            Deadline = deadline;
            IsCompleted = false;
        }
    }
}
