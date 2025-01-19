using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToDoList.Entities.Menus.Menu;

namespace ToDoList.Entities.FileController
{
    /// <summary>
    /// Class responsible for controlling the file stream
    /// </summary>
    internal static class FileController
    {
        // Static variables to store the path of the directory and the file
        public static string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ToDoList");
        public static string filePath = Path.Combine(directoryPath, "tasks.json");
        internal static void AddTask(Task task)
        {
            // Checking if the directory exists
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            string json = JsonConvert.SerializeObject(task);
            // If the file does not exist, it is created
            File.AppendAllLines(filePath, new string[] { json });


        }
        internal static void RemoveTask(int choosedTask)
        {
            List<Task> tasks = SearchTasks();
            // Checking if the task exists
            if (choosedTask > tasks.Count || choosedTask < tasks.Count)
            {
                Console.Clear();
                Console.WriteLine("Task not found");
                Thread.Sleep(3000);
                RemovingMenu();
            }

            for (int i = 1; i < tasks.Count; i++) 
            {
                if (tasks[i].Id == choosedTask)
                {
                    tasks.Remove(tasks[i]);
                    continue;
                }
            }

            File.Delete(filePath);
            foreach (var task in tasks)
            {
                string json = JsonConvert.SerializeObject(task);
                File.AppendAllLines(filePath, new string[] { json });
            }
        }
        internal static void EditTask(int choosedTask, Task task)
        {

            List<Task> tasks = SearchTasks();
            if(choosedTask > tasks.Count || choosedTask < tasks.Count)
            {
                Console.Clear();
                Console.WriteLine("Task not found");
                Thread.Sleep(3000);
                EditingMenu();
            }
            for (int i = 1; i < tasks.Count; i++)
            {
                if (tasks[i].Id == choosedTask)
                {
                    tasks[i] = task;
                    continue;
                }
            }
            File.Delete(filePath);
            foreach (var t in tasks)
            {
                string json = JsonConvert.SerializeObject(t);
                File.AppendAllLines(filePath, new string[] { json });
            }

        }
        /// <summary>
        /// Method to search for tasks in the file
        /// </summary>
        /// <returns></returns>
        internal static List<Task> SearchTasks()
        {
            List<Task> tasks = new List<Task>();
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    Task task = JsonConvert.DeserializeObject<Task>(line);
                    tasks.Add(task);
                }
            }
            return tasks;
        }
        // Util to return the next id
        internal static int GreaterId()
        {
            List<Task> tasks = SearchTasks();
            if (tasks.Count == 0)
                return 1;
            else
                return tasks.Max(t => t.Id) + 1;
        }
    }
}
