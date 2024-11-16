using FileSorting.Core.Configs;
using FileSorting.Core.Exceptions;
using FileSorting.Logging;
using FileSorting.Logging.SpecificLogger;

namespace FileSorting.Core
{
    internal class FileToMove
    {
        private readonly string fileNameOnly;
        private readonly ISortingConfig config;
        private readonly ILogger log;
        private readonly FileInfo file;

        public string CurrentPath { get; set; }
        public bool DirectoryExists { get => Directory.Exists(CurrentPath); }
        public bool FileExists { get => file.Exists; }

        public FileToMove(ISortingConfig config, FileInfo currentFile) : this(config, currentFile, new NullLogger()) { }
        public FileToMove(ISortingConfig config, FileInfo currentFile, ILogger logger)
        {
            file = currentFile;
            this.config = config;
            log = logger;
            fileNameOnly = this.file.Name.Split(".")[0];
            CurrentPath = config.SortingPath + "\\" + file.Extension[1..].ToUpper();
        }

        private bool MovedFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                file.MoveTo(filePath);
                log.InfoLog($"File {file} moved");
                return true;
            }
            return false;
        }
        public void MovingFile()
        {
            string currentFilePath = CurrentPath + "\\" + file.Name;

            for (int i = 1; !MovedFile(currentFilePath); i++)
            {
                switch (config.ChangeState)
                {
                    case ChangeNameState.Exception: throw new NameTakenException(file, $"File {file} already exists in the correct directory");
                    case ChangeNameState.Ignoring:
                        {
                            log.ErrorLog($"File {file.Name} already exists in the correct directory");
                            return;
                        }
                    case ChangeNameState.Change:
                        {
                            currentFilePath = CurrentPath + "\\" + fileNameOnly + $"({i})" + file.Extension;
                            break;
                        }
                }
            }
        }
    }
}
