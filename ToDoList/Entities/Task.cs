using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToDoList.Entities.FileController.FileController;

namespace ToDoList.Entities
{
    internal class Task
    {
        public int Id { get; private set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime CreationTime { get; private set; }
        public DateTime UpdatedTime { get; set; }

        public Task(int id, string description, DateTime? deadline)
        {
            Id = id;
            Description = description;
            Deadline = deadline;
            CreationTime = DateTime.Now;
            UpdatedTime = DateTime.Now;
        }

    }
}
