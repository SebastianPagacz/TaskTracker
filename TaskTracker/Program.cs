namespace TaskTracker;

internal class Program
{
    static void Main(string[] args)
    {
        RunnerMethods.DisplayHello();
        while (true)
        {
            bool exit = false;
            
            string input = Console.ReadLine();
            input = input.ToLower();
            
            switch (input)
            {
                case "help":
                    RunnerMethods.DisplayHelp();
                    break;
                case "exit":
                    exit = true;
                    break;
            }


            if (exit) 
            {
                break;
            }
        }
    }
}
