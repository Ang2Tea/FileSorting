using System.Diagnostics;

namespace FileSorting.Logging.SpecificLogger
{
    public class DebugLogger : ILogger
    {
        public void ErrorLog(string message)
        {
            Debug.Fail(message);
        }

        public void InfoLog(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
