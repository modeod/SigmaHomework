using SigmaHomework_6_ConsoleClient.Models;

namespace SigmaHomework_6_ConsoleClient.Services.Interfaces
{
    public interface IParserService
    {
        QuarterModel ParseJSON(string text);
        QuarterModel ParseTxt(string[] documentByLines);
    }
}