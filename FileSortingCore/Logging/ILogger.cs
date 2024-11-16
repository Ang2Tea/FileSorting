namespace FileSorting.Logging
{
    public interface ILogger
    {
        void InfoLog(string message);
        void ErrorLog(string message);
    }
}
