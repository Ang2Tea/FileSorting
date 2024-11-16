using FileSorting.Core.Configs;
using FileSorting.Logging;
using FileSorting.Logging.SpecificLogger;

namespace FileSorting.Core
{
    public class FilesSorting
    {
        private readonly ILogger log;
        private readonly ISortingConfig config;

        internal List<FileToMove> ListFile { get; set; }

        public FilesSorting(ISortingConfig config, ILogger log)
        {
            this.log = log;
            this.config = config;
            ListFile = new();
            foreach (string fileDir in Directory.GetFiles(this.config.SortingPath))
            {
                FileToMove file = new(this.config, new FileInfo(fileDir), this.log);
                ListFile.Add(file);
            }
        }
        public FilesSorting(ISortingConfig config) : this(config, new NullLogger()) { }

        public void StartMovingFile()
        {
            foreach (FileToMove file in this.ListFile)
            {
                if (!file.DirectoryExists)
                {
                    Directory.CreateDirectory(file.CurrentPath);
                    log.InfoLog($"Directory created {file.CurrentPath}");
                }

                if (file.FileExists)
                {
                    file.MovingFile();
                }
            }
        }
    }
}
