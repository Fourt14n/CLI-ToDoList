using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Entities.FileController
{
    internal static class FileController
    {
        public static string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ToDoList");
        public static string filePath = Path.Combine(directoryPath, "tasks.json");
        internal static void addTask(Task task)
        {

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            if (!File.Exists(filePath))
                File.Create(filePath);

            string json = JsonConvert.SerializeObject(task);

            Console.WriteLine(json);
            Thread.Sleep(5000);

            File.AppendAllLines(filePath, new string[] { json });


        }
        internal static List<Task> searchTasks()
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
        internal static void removeTask()
        {
            List<Task> tasks = searchTasks();
            Console.Clear();
            Console.WriteLine("-- Deleting task --");
            Console.WriteLine("Which task would you want to remove?");
            
            int choosedTask = int.Parse(Console.ReadLine());
            foreach(var task in tasks)
            {
                if(task.Id == choosedTask)
                {
                    tasks.Remove(task);
                    File.Delete(filePath);
                    addTask(task);
                    break;
                }
            }
        }
        internal static int greaterId()
        {
            List<Task> tasks = searchTasks();
            if (tasks.Count == 0)
                return 1;
            else
                return tasks.Max(t => t.Id) + 1;
        }
    }
}
