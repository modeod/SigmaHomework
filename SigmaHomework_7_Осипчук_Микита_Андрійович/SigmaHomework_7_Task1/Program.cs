using System.Text;
using SigmaHomework_7_Task1.Enums;
using SigmaHomework_7_Task1.ProductsModels;
using SigmaHomework_7_Task1.StorageEcosystem;

namespace SigmaHomework_7_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Hello, World!");

            CheckChild check = new CheckChild();

            ProductModel productKitten = new("Kitten", 20M, 3.5F);
            ProductModel productBob = new("Bob", 1, 72.4F, Courency.USD);
            ProductModel productFoo = new("Foo", 1, 72.4F, Courency.USD);
            ProductModel productBaa = new("Baa", 1, 72.4F, Courency.USD);
            ProductModel productFooBaa = new("FooBaa", 1, 72.4F, Courency.USD);

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

            Storage storage = new Storage(new StorageItem(productKitten), new StorageItem(productBob), new StorageItem(productFoo));
            Storage storage2 = new Storage(new StorageItem(productBob), new StorageItem(productFoo), new StorageItem(productBaa));

            StorageClient storageClient = new StorageClient(storage);

            //storageClient.AddProductsToStorageWithConsole();
            storageClient.Print();

            Console.WriteLine(new String('-', 10));
// Мало бути 3 результати. 
            
            var result1 = storage.GetProductsFirstStorageHaveAndSecondDont(storage2);
            var result2 = storage.GetProductsInnerJoin(storage2);

            Console.ReadKey();

        }
    }
}
