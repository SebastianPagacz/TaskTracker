namespace TaskTracker;

internal class Program
{
    static void Main(string[] args)
    {
        Task task1 = new Task("test");
        Task task2 = new Task("test1");
        Task task3 = new Task("test2");
        TaskHandling.AddTask(task1);
        string input  = Console.ReadLine();
        if (input == "a") 
        {
            TaskHandling.UpdateTask(0, "test2");
        }
        TaskHandling.ShowTasks();
        TaskHandling.RemoveTask(0);
        TaskHandling.ShowTasks();
    }
}
