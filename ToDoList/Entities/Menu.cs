using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Entities;

namespace ToDoList.Entities
{
    // Define the menu class, used static to not create an instance of the class
    internal static class Menu
    {
        internal static EShowMenu InitialMenu()
        {
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

                return (EShowMenu)int.Parse(Console.ReadLine());

            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine("Use only numbers!");
                Thread.Sleep(2000);
                return EShowMenu.Returning;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return EShowMenu.Returning;
            }


        }
    }
}
