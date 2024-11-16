using FileSorting.Core;
using FileSorting.Core.Configs;
using FileSortingConsole;
using FileSortingConsole.Parser;

ConfigParser<StandartConfig> configParser = new(Environment.GetCommandLineArgs()[1]);
ConsoleLogger logger = new();
FilesSorting sorting = new(configParser.Parse(), logger);

sorting.StartMovingFile();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Sorting complete!");
Console.ResetColor();
Console.ReadLine();