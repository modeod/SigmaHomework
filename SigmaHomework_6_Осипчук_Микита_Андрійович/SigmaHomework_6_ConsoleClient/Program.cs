using SigmaHomework_6_ConsoleClient.Models;
using SigmaHomework_6_ConsoleClient.Services;
using SigmaHomework_6_ConsoleClient.Services.Interfaces;
using System.Text;

namespace SigmaHomework_6_ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string InputFilePath = exeDir + Settings.QuarterFilePath;
            string OutputFilePath = exeDir + Settings.OutputReportFilePath;

            IFileHandler fileHandler = new FileHandler(InputFilePath, OutputFilePath);
            IParserService parser = new ParserService();

            QuarterFileHandlerService quarterFileService = new QuarterFileHandlerService(
                fileHandler,
                parser);

            QuarterModel quart = quarterFileService.GetQuarterFromFile();
            QuarterService quarterService = new(quart);

            quarterFileService.WriteReadableQuarterToFile(quart);
            quarterFileService.WriteReadableQuarterItemInformationToFile(quart[0]);
            quarterFileService.WriteDaysPassedFromLastEnergyMeterReadingToFile(quarterService.GetDaysPassedFromLastEnergyMeterReading());

            Console.WriteLine(File.ReadAllText(InputFilePath));
        }
    }
}