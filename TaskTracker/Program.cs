namespace TaskTracker;

internal class Program
{
    static void Main(string[] args)
    {
        string[] stringArr;
        
        FileHandling.GetFileContent();
        RunnerMethods.DisplayHello();
        while (true)
        {
            bool exit = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("task-cli: ");
            Console.ResetColor();
            string input = Console.ReadLine() ?? "";
            stringArr = input.Split(" ");
            try 
            {
                switch (stringArr[0].ToLower())
                {
                    case "help":
                        RunnerMethods.DisplayHelp();
                        break;
                    case "add":
                        TaskHandling.AddTask(String.Join(" ", stringArr[1..]));
                        break;
                    case "update":
                        TaskHandling.UpdateTask(int.Parse(stringArr[1]), String.Join(" ", stringArr[2..]));
                        break;
                    case "delete":
                        TaskHandling.RemoveTask(int.Parse(stringArr[1]));
                        break;
                    case "mark":
                        TaskHandling.ChangeStatus(int.Parse(stringArr[1]), stringArr[2]);
                        break;
                    case "list":
                        TaskHandling.ShowTasksStatuses(stringArr[1]);
                        break;
                    case "show-tasks":
                        TaskHandling.ShowAllTasks();
                        break;
                    case "show":
                        TaskHandling.ShowTask(int.Parse(stringArr[1]));
                        break;
                    case "exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
            catch (Exception) 
            { 
                // TODO: add own exceptions for diffrent cases
                Console.WriteLine("Invalid command, you might be missing a positional argument"); 
            }
            if (exit) 
            {
                break;
            }
        }
    }
}
