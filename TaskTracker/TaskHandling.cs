using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker;

public class TaskHandling
{
    // Main Dictionary containg all the tasks saved in the file
    public static Dictionary<int, Task> IdTasks = new Dictionary<int, Task>();

    // Tasks manipulation methods
    public static void AddTask(string description)
    {
        Task task = new Task(description);
        
        // Autoincremented id field for the task, the gets smallest id that is not taken
        int counter = 0;
        while (IdTasks.ContainsKey(counter))
        {
            counter++;   
        }

        Console.WriteLine($"Task added successfully (ID: {counter})");
        
        // Adds id to the dictionary and saves the file
        IdTasks.Add(counter, task);
        FileHandling.SaveToFile();
    }

    public static void UpdateTask(int taskId, string description)
    {
        if (IdTasks.ContainsKey(taskId))
        {
            // Updates tasks Description and UpdatedAt accordingly, then saves the file
            IdTasks[taskId].Description = description;
            IdTasks[taskId].UpdatedAt = DateTime.Now;
            Console.WriteLine($"Task updated successfully (ID: {taskId})");
            FileHandling.SaveToFile();
        }
        else
        {
            Console.WriteLine($"Task with ID: {taskId} not found");
        }
    }

    public static void RemoveTask(int taskId)
    {
        // Remvoes the task if id present in the dictionary
        if (IdTasks.ContainsKey(taskId))
        {
            IdTasks.Remove(taskId);
            Console.WriteLine($"Task removed successfully (ID: {taskId})");
            FileHandling.SaveToFile();
        }
        else
        {
            Console.WriteLine($"Task with ID: {taskId} not found");
        }
    }
    // Status manipulaton methods
    public static void ChangeStatus(int taskId, string newStatus)
    {
        newStatus = StatusSwitch(taskId, newStatus);
        Console.WriteLine($"Status chnaged for task {taskId}, new status is {IdTasks[taskId].TaskStatus}");
        FileHandling.SaveToFile();
    }

    private static string StatusSwitch(int taskId, string newStatus)
    {
        newStatus = newStatus.ToLower();
        if (IdTasks.ContainsKey(taskId))
        {
            switch (newStatus)
            {
                case "todo":
                    IdTasks[taskId].TaskStatus = Enums.TaskTrackerStatus.ToDo;
                    IdTasks[taskId].UpdatedAt = DateTime.Now;
                    break;
                case "in-progress":
                    IdTasks[taskId].TaskStatus = Enums.TaskTrackerStatus.InProgress;
                    IdTasks[taskId].UpdatedAt = DateTime.Now;
                    break;
                case "done":
                    IdTasks[taskId].TaskStatus = Enums.TaskTrackerStatus.Done;
                    IdTasks[taskId].UpdatedAt = DateTime.Now;
                    break;
            }
        }
        else
        {
            Console.WriteLine($"Task with ID: {taskId} not found");
        }

        return newStatus;
    }

    // Iterates through the dictionary to show all the task with given status

    public static void ShowTasksStatuses(string taskStatus)
    {
        // Prases string into Enums.TaskTrackerStatus
        Enums.TaskTrackerStatus enumTaskStatus = TrackerStatusPraser(taskStatus);

        Console.WriteLine($"{enumTaskStatus} tasks:");
        foreach (KeyValuePair<int, Task> task in IdTasks)
        {
            if (task.Value.TaskStatus == enumTaskStatus)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine($"ID: {task.Key} \nDescription: {task.Value.Description} \nCreated at: {task.Value.CreatedAt}\nUpdated at: {task.Value.UpdatedAt}\nTask status: {task.Value.TaskStatus}");
            }
        }
    }

    // Prases string into Enums.TaskTrackerStatus
    private static Enums.TaskTrackerStatus TrackerStatusPraser(string taskStatus)
    {
        taskStatus = taskStatus.ToLower();
        switch (taskStatus)
        {
            case "todo":
                return Enums.TaskTrackerStatus.ToDo;
            case "in-progress":
                return Enums.TaskTrackerStatus.InProgress;
            case "done":
                return Enums.TaskTrackerStatus.Done;
            default:
                Console.WriteLine("invalid input");
                break;
        }
        throw new Exception("invalid input");
    }
    public static void ShowAllTasks()
    {
        foreach (KeyValuePair<int, Task> task in IdTasks)
        {
            Console.WriteLine("-----------------");
            Console.WriteLine($"ID: {task.Key} \nDescription: {task.Value.Description} \nCreated at: {task.Value.CreatedAt}\nUpdated at: {task.Value.UpdatedAt}");
        }
    }

    public static void ShowTask(int taskId)
    {
        if (IdTasks.ContainsKey(taskId)) 
        {
            Console.WriteLine("-----------------");
            Console.WriteLine($"ID: {taskId} \nDescription: {IdTasks[taskId].Description} \nStatus: {IdTasks[taskId].TaskStatus}\nCreated at: {IdTasks[taskId].CreatedAt}\nUpdated at: {IdTasks[taskId].UpdatedAt}");
        }
        else
        {
            Console.WriteLine($"Task with ID: {taskId} not found");
        }
    }
}
