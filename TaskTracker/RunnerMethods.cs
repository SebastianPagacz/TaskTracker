using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker;

public class RunnerMethods
{
    private static Dictionary<string, string> _userManualDictionary = new Dictionary<string, string>
    {
        ["add"] = "Adds task to the list [description]",
        ["update"] = "Based on provided task id updates the given task [id] [description]",
        ["remove"] = "Based on provided task id removes the given task from the list [id]",
        ["change-status"] = "Based on provided task id changes the given task status [id] [status]",
        ["show-task"] = "Displays tasks with given id [id]",
        ["show-tasks"] = "Displays all tasks with given status [status]",
        ["show-all-tasks"] = "Displays all tasks",
        ["exit"] = "Exits the application"
    };
        
    public static void DisplayHelp()
    {
        foreach(var element in _userManualDictionary)
        {
            Console.WriteLine($"{element.Key} - {element.Value}");
        }
    }

    public static void DisplayHello()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Task Tracker Cli v1.0");
        Console.ResetColor();
        Console.WriteLine("Type help to display user mannual");
    }
}
