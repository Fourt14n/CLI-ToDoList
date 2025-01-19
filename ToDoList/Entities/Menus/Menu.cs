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
                        AddingMenu(); InitialMenu(); break;
                    case 2:
                        { 
                            Console.Clear(); 
                            Console.WriteLine("-- Listing Tasks --");  
                            if(ListingMenu() == 0)
                            {
                                Console.WriteLine("No tasks found to list");
                            }
                                Console.WriteLine("");
                            Console.WriteLine("Press any key to return to the main menu");
                            Console.ReadKey();
                            InitialMenu(); 
                            break;
                        }
                    case 3:
                        RemovingMenu(); InitialMenu(); break;
                    case 4:
                        EditingMenu(); InitialMenu(); break;
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
                Console.WriteLine(e);
                Thread.Sleep(10000);
                InitialMenu();
            }


        }
        internal static void AddingMenu()
        {

            List<Task> tasks = SearchTasks();
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
            Task task = new Task(GreaterId(), description, deadline);

            AddTask(task);
            Console.Clear();
            Console.WriteLine("Task added successfully!");
            Thread.Sleep(3000);
        }
        internal static void EditingMenu() {
            DateTime? deadline = null;

            Console.Clear();
            Console.WriteLine("-- Editing task --");
            if(ListingMenu() == 0)
            {
                Console.WriteLine("No tasks to edit");
                Console.WriteLine("");
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
                InitialMenu();
                return;
            }
            Console.WriteLine("");
            Console.WriteLine("Which task would you want to edit?");
            int choosedTask = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.Write("Task description:");
            string description = Console.ReadLine();
            for (int i = 0; i != 1;)
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
            Task task = new Task(choosedTask, description, deadline);
            EditTask(choosedTask, task);

            Console.Clear();
            Console.WriteLine("Task edited successfully!");
            Thread.Sleep(3000);

        }

        internal static int ListingMenu() {
            List<Task> tasks = SearchTasks();
            if(tasks.Count < 1)
            {
                return 0;
            }
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
            return 1;

        }

        internal static void RemovingMenu() {
            Console.Clear();
            Console.WriteLine("-- Deleting task --");
            if(ListingMenu() == 0)
            {
                Console.WriteLine("No tasks to delete");
                Console.WriteLine("");
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
                InitialMenu();
                return;
            }
            Console.WriteLine("");
            Console.WriteLine("Which task would you want to remove?");
            int choosedTask = int.Parse(Console.ReadLine());
            RemoveTask(choosedTask);
        }

    }
}
