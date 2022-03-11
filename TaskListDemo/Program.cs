using System;

namespace TaskListDemo
{
    class MainClass
    {
        static void Main()
        {
            string[] tasks = new string[5];

            // Viewing should only show populated array slots
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
