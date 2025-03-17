using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker;

public class TaskHandling
{
    private static Dictionary<int, Task> IdTasks = new Dictionary<int, Task>();
    public static void AddTask(Task task)
    {
        // TODO: change id assingment logic
        IdTasks.Add(IdTasks.Count() ,task);
    }

    public static void UpdateTask(int taskId, string description)
    {
        if (!IdTasks.ContainsKey(taskId))
        {
            throw new Exception("There is no task coresponding");
        }
        IdTasks[taskId].Description = description;
        IdTasks[taskId].UpdatedAt = DateTime.Now;
    }

    public static void RemoveTask(int taskId)
    {
        if (IdTasks.ContainsKey(taskId))
        {
            IdTasks.Remove(taskId);
            Console.WriteLine("Task removed");
        }
        else
        {
            throw new Exception("There is no task coresponding");
        }
    }
    public static void ShowTasks()
    {
        foreach(KeyValuePair<int, Task> task in IdTasks)
        {
            Console.WriteLine($"{task.Key} : {task.Value.Description} \nCreated at: {task.Value.CreatedAt}\nUpdated at: {task.Value.UpdatedAt}");
        }
    }
}
