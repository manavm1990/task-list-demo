using System;
using System.Collections.Generic;

namespace TaskListDemo
{
  static class MainClass
  {
    static void Main()
    {
      string[] tasks = new string[5];

      // Comment 💡 👇🏾 if don't want to seed 🗃️
      tasks = Seed4OutOf5Tasks(tasks);

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
            tasks = RemoveTasks(tasks);
            break;

          // No break needed here
          // Want this to work for either case
          case "Q":
          case "q":
            Console.WriteLine("Goodbye! 👋🏾");
            isRunning = false;
            break;

          default:
            Console.WriteLine("Invalid input");
            Prompt2Continue();
            break;
        }
      }
    }

    // We could just have the method reach outside of itself and grab 'tasks' directly. 👎🏾
    private static string[] AddTask(string[] currentTasks)
    {
      int len = currentTasks.Length;
      string newTask = PromptRequired("Enter Task: ");
      int freeIndex = FindOpenIndex(currentTasks);

      // R there any empty spots or do we need to resize?
      if (freeIndex == -1)
      {
        // Increase size by 1
        Array.Resize(ref currentTasks, len + 1);

        // Add new task to the end of the array (last index is original length, len) 👆🏾
        currentTasks[len] = newTask;
      }
      // If we have an open index, add the new task there
      else
      {
        currentTasks[freeIndex] = newTask;
      }

      Console.WriteLine($"{newTask} is on the list!");
      Prompt2Continue();
      return currentTasks;
    }


    private static string[] RemoveTasks(string[] currentTasks)
    {
      ViewTasks(currentTasks);
      int currentTasksLength = currentTasks.Length;

      if (currentTasksLength == 0)
      {
        Console.WriteLine("There are no tasks to remove!");
        Prompt2Continue();
        return currentTasks;
      }

      int index2Remove = PromptUser4Int("Enter Task to remove:", 1, currentTasksLength) - 1;

      string removedTask = currentTasks[index2Remove];
      currentTasks[index2Remove] = null;

      // Create a new array for tasks that is empty to start, but is one less in length than the original
      string[] updatedTasks = Array.Empty<string>();

      for (int i = 0; i < currentTasksLength; i++)
      {
        // Skip over null values
        if (currentTasks[i] == null)
        {
          continue;
        }

        // Keep growing the array by 1️⃣
        Array.Resize(ref updatedTasks, updatedTasks.Length + 1);
        updatedTasks[updatedTasks.Length - 1] = currentTasks[i];
      }

      Console.WriteLine($"{removedTask} has been removed");
      Prompt2Continue();

      return updatedTasks;
    }

    private static string[] Seed4OutOf5Tasks(string[] tasks)
    {
      tasks[0] = "Dishes 🥣";
      tasks[1] = "Bills 💸";
      tasks[2] = "Groceries 🥫";
      tasks[3] = "Vacuum";

      return tasks;
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

Enter Choice:
");

      return Console.ReadLine();
    }

    private static void ViewTasks(IReadOnlyList<string> currentTasks)
    {
      for (int i = 0; i < currentTasks.Count; i++)
      {
        string currentTask = currentTasks[i];

        if (!string.IsNullOrEmpty(currentTask))
        {
          Console.WriteLine($"{i + 1}. {currentTasks[i]}");
        }
      }
    }

    // TODO: 🚚 Move to a utility class
    private static int FindOpenIndex(IReadOnlyList<string> strings)
    {
      const int openIndex = -1;

      for (int i = 0; i < strings.Count; i++)
      {
        if (string.IsNullOrEmpty(strings[i]))
        {
          return i;
        }
      }

      return openIndex;
    }

    // TODO: Move 🚚 this methods to a View class
    private static void Prompt2Continue()
    {
      Console.WriteLine("=====================================");
      Console.WriteLine("Press any key to continue...");

      Console.ReadLine();
    }

    private static string PromptRequired(string message)
    {
      string res = PromptUser(message);
      while (string.IsNullOrEmpty(res))
      {
        Console.WriteLine("Input required❗");
        res = PromptUser(message);
      }

      return res;
    }

    private static string PromptUser(string message)
    {
      Console.Write(message);
      return Console.ReadLine();
    }

    private static int PromptUser4Int(string message, int min, int max)
    {
      int result;
      while (!(int.TryParse(PromptUser(message), out result)) || result < min || result > max)
      {
        PromptUser($@"Invalid Input, must be between {min} and {max}
Press Enter to Continue");
      }

      return result;
    }
  }
}
