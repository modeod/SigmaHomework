using System.Text;
using SigmaHomework_5_Task1.Enums;
using SigmaHomework_5_Task1.ProductsModels;
using SigmaHomework_5_Task1.StorageEcosystem;

namespace SigmaHomework_5_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {// немає перехоплень винятків, які можуть виникати
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Hello, World!");

            CheckChild check = new CheckChild();

            ProductModel productKitten = new("Goose", 20M, 3.5F);
            ProductModel productBob = new("Milk", 1, 72.4F, Courency.USD);

            Buy buyKittens = new(productKitten, 2);
            Buy buyBobs = new(productBob, 1);

            Cart cart = new Cart(Courency.UAN, buyKittens, buyBobs);

            check.Print(productKitten);
            check.Print(buyKittens);
            check.Print(productBob);
            check.Print(buyBobs);

            Console.WriteLine(new String('-', 10));

            check.Print(cart);

            Console.WriteLine(new String('-', 10));

            Storage storage = new Storage(productKitten, productBob);
            StorageClient storageClient = new StorageClient(storage);

            storageClient.AddProductsToStorageWithConsole();
            storageClient.Print();

            Console.WriteLine(new String('-', 10));
        }
    }
}
