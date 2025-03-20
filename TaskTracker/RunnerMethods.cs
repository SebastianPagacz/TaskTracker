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
        ["delete"] = "Based on provided task id removes the given task from the list [id]",
        ["mark"] = "Based on provided task id changes the given task status [id] [status]",
        ["show"] = "Displays tasks with given id [id]",
        ["list"] = "Displays all tasks with given status [status]",
        ["show-tasks"] = "Displays all tasks",
        ["exit"] = "Exits the application",
        ["todo"] = "To do status",
        ["done"] = "Done status",
        ["in-progress"] = "In progress status",
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
