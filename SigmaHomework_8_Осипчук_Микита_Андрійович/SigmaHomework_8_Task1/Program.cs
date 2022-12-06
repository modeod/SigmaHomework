using SigmaHomework_8_Task1.Services;
using SigmaHomework_8_Task1.Services.Interfaces;
using System.Text;

namespace SigmaHomework_8_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            string exeDir = AppDomain.CurrentDomain.BaseDirectory;

            IFileHandler orderFileHandler = new FileHandler(exeDir + Config.OrderFileName, "");
            IFileHandler substitutionsFileHandler = new FileHandler(exeDir + Config.SubstitutionsFileName, "");
            IFileHandler resultFileHandler = new FileHandler(exeDir + Config.ResultFileName, exeDir + Config.ResultFileName);

            IStorageService storageService = new StorageService();

            ParserService parserService = new ParserService();

            ISubstitutionsService substitutionsService = new SubstitutionsService(parserService, substitutionsFileHandler);

            OrderService orderService = new OrderService(parserService, orderFileHandler, storageService);

            UnsatisfiedOrderItemService unsatisfiedOrderItemService = new UnsatisfiedOrderItemService(
                substitutionsService,
                resultFileHandler,
                storageService);

            orderService.OrderСannotBeSatisfiedNotify += unsatisfiedOrderItemService.OnOrderUnsatisfied;

            try
            {
                orderService.AnalyzeOrders();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}