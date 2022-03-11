using System;

namespace TaskListDemo
{
    class MainClass
    {
        static void Main()
        {
            string[] tasks = new string[5];

            // Viewing should only show populated array slots
            // Switch-case to respond to menu choices
            bool isRunning = true;

            while (isRunning)
            {
                switch (Select())
                {
                    case "1":
                        Console.WriteLine("View List");
                        break;
                    case "2":
                        Console.WriteLine("Add Task");
                        break;
                    case "3":
                        Console.WriteLine("Remove A Task");
                        break;
                    default:
                        isRunning = false;
                        break;
                }
            }

            // Add a task (option #2)
        }

        private static string Select()
        {
            Console.Write(@"Task List
=====================================
1. View List
2. Add a Task
3. Remove a Task

Press Q to quit
=====================================

Enter Choice:");

            return Console.ReadLine();
            // TODO: Compare the userChoice with what's in the menu
        }
    }
}
