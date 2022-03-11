﻿using System;
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
            tasks = RemoveTasks(tasks);
            break;
          default:
            isRunning = false;
            break;
        }
      }
    }

    // We could just have the method reach outside of itself and grab 'tasks' directly. 👎🏾
    private static string[] AddTask(string[] currentTasks)
    {
      Console.WriteLine("Enter the task:");
      // TODO: Consider moving the job of asking (and validating) for the task to a separate method
      string newTask = Console.ReadLine();

      for (int i = 0; i < currentTasks.Length; i++)
      {
        if (!string.IsNullOrEmpty(currentTasks[i]))
        {
          continue;
        }

        currentTasks[i] = newTask;
        break;
      }

      return currentTasks;
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

    private static string[] RemoveTasks(string[] currentTasks)
    {
      ViewTasks(currentTasks);
      int index2Remove =

        // This is an improvement over the previous version that we wrote in the class as it allows for min and max
        // ranges
        PromptUser4Int("Enter Task to remove:", 1, currentTasks.Length);

      string removedTask = currentTasks[index2Remove];
      currentTasks[index2Remove] = null;

      // Create a new array or tasks that is empty to start, but is one less in length than the original
      string[] updatedTasks = new string[currentTasks.Length - 1];

      // This loop runs only over updatedTasks, which is one less in length than currentTasks
      for (int i = 0; i < updatedTasks.Length; i++)
      {
        string currentTask = currentTasks[i];

        // If the current task (at index i) is not null, then we want to add it to the updatedTasks array
        if (!string.IsNullOrEmpty(currentTask)) updatedTasks[i] = currentTask;
      }

      Console.WriteLine($"{removedTask} has been removed");

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

Enter Choice:");

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
  }
}
