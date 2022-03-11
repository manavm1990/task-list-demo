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
                        ViewTasks(tasks);
                        break;
                    case "2":
                        // Replace the tasks with the new version
                        // We don't want our methods to directly access our global tasks
                        tasks = AddTask(tasks);
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

        // We could just have the method reach outside of itself and grab 'tasks' directly. 👎🏾
        private static string[] AddTask(string[] currentTasks)
        {
            Console.WriteLine("Enter the task:");
            // TODO: Consider moving the job of asking (and validating) for the task to a separate method
            string newTask = Console.ReadLine();

            for (int i = 0; i < currentTasks.Length; i++)
            {
                if (string.IsNullOrEmpty(currentTasks[i]))
                {
                    currentTasks[i] = newTask;
                    break;
                }
            }

            return currentTasks;
        }

        private static string[] RemoveTasks(string[] currentTasks, string task2Remove)
        {
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

        private static void ViewTasks(string[] currentTasks)
        {
            for (int i = 0; i < currentTasks.Length; i++)
            {
                string currentTask = currentTasks[i];

                if (!string.IsNullOrEmpty(currentTask))
                {
                    Console.WriteLine($"{i + 1}. {currentTasks[i]}");
                }
            }
        }
    }
}
