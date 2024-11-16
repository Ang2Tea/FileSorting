namespace FileSorting.Logging.SpecificLogger
{
    internal class NullLogger : ILogger
    {
        public void ErrorLog(string message) { }

        public void InfoLog(string message) { }
    }
}
