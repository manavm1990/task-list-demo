using System;

namespace TaskListDemo
{
  static class MainClass
  {
    static void Main()
    {
      const int numOfTasks = 5;
      string[] tasks = new string[numOfTasks];

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

    private static string[] RemoveTasks(string[] currentTasks)
    {
      ViewTasks(currentTasks);
      Console.WriteLine("Enter Task to remove:");

      // TODO: Validate this with a tryParse
      int index2Remove = int.Parse(Console.ReadLine() ?? string.Empty) - 1;
      currentTasks[index2Remove] = null;

      // TODO: Shift all the tasks so that there are no gaps in the array.
      for (int i = index2Remove; i < currentTasks.Length; i++)
      {
        if (i == currentTasks.Length - 1)
        {
          // This is the very last task.
          // It has already been removed if it was the one to remove
          currentTasks[i] = null;
        }
        else
        {
          currentTasks[i] = currentTasks[i + 1];
        }
      }

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
