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
                        Console.WriteLine($"Added a new task in the first slot: Here it is: ${AddTask(tasks)[0]}");
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

        private static string[] AddTask(string[] currentTasks)
        {
            Console.WriteLine("Enter the task:");
            // TODO: Consider moving the job of asking for the task to a separate method
            string newTask = Console.ReadLine();

            for (int i = 0; i < currentTasks.Length; i++) if (string.IsNullOrEmpty(currentTasks[i])) currentTasks[i] = newTask;

            return currentTasks;
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
