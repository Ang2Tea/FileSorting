using FileSorting.Logging;

namespace FileSortingConsole
{
    internal class ConsoleLogger : ILogger
    {
        public void ErrorLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error# " + message);
            Console.ResetColor();
        }

        public void InfoLog(string message)
        {
            Console.WriteLine("Info# " + message);
        }
    }
}
