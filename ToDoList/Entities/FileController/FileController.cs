using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToDoList.Entities.Menus.Menu;

namespace ToDoList.Entities.FileController
{
    internal static class FileController
    {
        public static string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ToDoList");
        public static string filePath = Path.Combine(directoryPath, "tasks.json");
        internal static void AddTask(Task task)
        {

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            string json = JsonConvert.SerializeObject(task);

            File.AppendAllLines(filePath, new string[] { json });


        }
        internal static void RemoveTask(int choosedTask)
        {
            List<Task> tasks = SearchTasks();


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
