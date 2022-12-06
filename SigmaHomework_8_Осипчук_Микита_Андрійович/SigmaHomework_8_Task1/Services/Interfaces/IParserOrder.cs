using SigmaHomework_8_Task1.Models;

namespace SigmaHomework_8_Task1.Services.Interfaces
{
    public interface IParserOrder
    {
        OrderModel[] ParseTxtOrders(string[] documentByLines);
    }
}