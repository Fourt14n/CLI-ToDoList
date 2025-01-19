using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToDoList.Entities.FileController.FileController;


namespace ToDoList.Entities.Menus
{
    // Define the menu class, used static to not create an instance of the class
    internal static class Menu
    {
        internal static void InitialMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the to-do list!");
            Console.WriteLine("-------------------------");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Add a task");
            Console.WriteLine("2 - List tasks");
            Console.WriteLine("3 - Exclude a task");
            Console.WriteLine("4 - Edit a task");
            Console.WriteLine("5 - Exit");

            try
            {
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddingMenu(); break;
                    case 2:
                        ListingMenu(); break;
                    case 3:
                        RemovingMenu(); break;
                    case 4:
                        EditingMenu(); break;
                    case 5:
                        Console.Clear(); Console.WriteLine("Exiting..."); Thread.Sleep(2000); break;
                    default:
                        Console.Clear(); Console.WriteLine("Invalid option, try again"); Thread.Sleep(2000); InitialMenu(); break;


                }


            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine("Use only numbers!");
                Thread.Sleep(3000);
                InitialMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, please try again");
                InitialMenu();
            }


        }
        internal static void AddingMenu()
        {

            List<Task> tasks = searchTasks();
            DateTime? deadline = null;

            Console.Clear();
            Console.WriteLine("-- Adding a task --");
            Console.WriteLine("");
            Console.Write("Task description:");
            string description = Console.ReadLine();
            for(int i = 0; i != 1;)
            {
            Console.WriteLine("Do you want to set a deadline? (Y/N)");
            string answer = Console.ReadLine().ToUpper();
                if (answer == "Y")
                {
                    for (int a = 0; a != 1;)
                    {
                        try
                        {

                            Console.Write("Task deadline: (DD/MM/YYYY)");
                            deadline = DateTime.Parse(Console.ReadLine());
                            a++;
                            i++;

                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Invalid date format, try again");
                        }
                    }
                }
                else if (answer == "N")
                {

                    i++;
                }
                else
                {
                    Console.WriteLine("Invalid option, try again");

                }
            }
            Task task = new Task(greaterId(), description, deadline);

            addTask(task);


            Console.WriteLine("Task added successfully!");
        }
        internal static void EditingMenu() { }

        internal static void ListingMenu() {
            List<Task> tasks = searchTasks();

            foreach(var task in tasks)
            {
                Console.WriteLine("");
                Console.Write($"Task: {task.Id} \n");
                Console.Write($"Description: {task.Description} \n");
                Console.Write($"Creation time: {task.CreationTime}\n");
                Console.Write($"Updated time: {task.UpdatedTime}\n");
                if(task.Deadline != null)
                    Console.Write($"Deadline: {task.Deadline}\n");
            }

        }

        internal static void RemovingMenu() { }

    }
}
