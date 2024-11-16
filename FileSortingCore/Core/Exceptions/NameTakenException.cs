namespace FileSorting.Core.Exceptions
{
    internal class NameTakenException : Exception
    {
        public FileInfo File { get; set; }

        public NameTakenException(FileInfo file, string? message) : base(message)
        {
            File = file;
        }
        public NameTakenException(FileInfo file) : this(file, "This file already exists in the correct directory")
        {
            File = file;
        }
    }
}
