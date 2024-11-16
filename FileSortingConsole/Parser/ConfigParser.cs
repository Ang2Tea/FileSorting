using FileSorting.Core.Configs;
using System.Text.Json;
using System.Text;

namespace FileSortingConsole.Parser
{
    internal class ConfigParser<T> where T : ISortingConfig
    {
        private readonly string configPath;

        public ConfigParser() : this("config.json") { }
        public ConfigParser(string configPath)
        {
            this.configPath = configPath;
        }

        public static ISortingConfig Parse<TConfig>(string configPath) where TConfig: ISortingConfig
        {
            return new ConfigParser<TConfig>(configPath).Parse();
        }
        public ISortingConfig Parse()
        {
            string fileText;
            using (StreamReader reader = new(configPath, Encoding.UTF8))
            {
                fileText = reader.ReadToEnd();
                reader.Close();
            }

            T? config = JsonSerializer.Deserialize<T>(fileText);
            if (config is null) throw new NullConfigException();
            return config;
        }
    }
}
