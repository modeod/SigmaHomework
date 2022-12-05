using SigmaHomework_8_Task1.Models;

namespace SigmaHomework_8_ConsoleClient.Services.Interfaces
{
    public interface IParserService
    {
        OrderModel[] ParseTxtOrders(string[] documentByLines);

        SubstitutionsModel ParseTxtSubstitutions(string[] documentByLines);
    }
}