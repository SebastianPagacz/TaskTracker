using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TaskTracker;

public class FileHandling
{
    private static readonly string _fileName = "Tasks.json";
    // Gets file content, if file is empty initializes new empty dictionary
    public static void GetFileContent()
    {
        if (!File.Exists(_fileName))
        {
            File.Create(_fileName).Dispose();
        }

        var fileData = File.ReadAllText(_fileName);
        TaskHandling.IdTasks = JsonConvert.DeserializeObject<Dictionary<int, Task>>(fileData);

        if (TaskHandling.IdTasks == null || !TaskHandling.IdTasks.Any()) 
        {
            TaskHandling.IdTasks = new Dictionary<int, Task>();
        }
    }

    // Adds IdTasks dictionary to the file
    public static void SaveToFile()
    {
        string json = JsonConvert.SerializeObject(TaskHandling.IdTasks, Formatting.Indented);
        File.WriteAllText(_fileName, json);
    }
}
