using System.Text;
using SigmaHomework_3_Task1.Enums;
using SigmaHomework_3_Task1.ProductsModels;

namespace SigmaHomework_3_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Hello, World!");

            Check check = new Check();

            ProductModel productKitten = new("Goose", 20M, 3.5F);
            ProductModel productBob = new("Milk", 4000.56M, 72.4F);

            Buy buyKittens = new(productKitten, 6);
            Buy buyBobs = new(productBob, 2);

            check.Print(productKitten);
            check.Print(buyKittens);
            check.Print(productBob);
            check.Print(buyBobs);

            Console.WriteLine(new String('-', 10));

            Storage storage = new Storage(productKitten, productBob);
            StorageClient storageClient = new StorageClient(storage);

            storageClient.AddProductsToStorageWithConsole();
            storageClient.Print();

            Console.WriteLine(new String('-', 10));

        }
    }
}