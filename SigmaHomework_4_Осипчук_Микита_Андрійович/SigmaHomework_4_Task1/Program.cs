using System.Text;
using SigmaHomework_4_Task1.Enums;
using SigmaHomework_4_Task1.ProductsModels;

namespace SigmaHomework_4_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Hello, World!");

            CheckChild check = new CheckChild();

            ProductModel productKitten = new("Goose", 20M, 3.5F);
            ProductModel productBob = new("Milk", 1M, 72.4F, Courency.USD);
            ProductModel productBiba = new("Biba", 20M, 3.5F);
            MeatModel productLamb = new("Lamb", 245M, 1F, MeatType.Lamb);

            Buy buyKittens = new(productKitten, 2);
            Buy buyBobs = new(productBob, 1);
            Buy buyBiba = new(productBiba, 1);
            Buy buyLamb = new(productLamb, 3);


            Cart cart = new Cart(Courency.UAN, buyKittens, buyBobs, buyBiba, buyLamb);

            check.Print(productKitten);
            check.Print(buyKittens);
            check.Print(productBob);
            check.Print(buyBobs);
            check.Print(buyBiba);
            check.Print(buyLamb);

            Console.WriteLine(new String('-', 10));

            check.Print(cart);

            Console.WriteLine(new String('-', 10));

            Storage storage = new Storage(productKitten, productBob, productBiba, productLamb);
            StorageClient storageClient = new StorageClient(storage);

            //storageClient.AddProductsToStorageWithConsole();
            storageClient.Print();

            storage.SortProductsByIdAscending();
            storageClient.Print();

            storage.SortProductsByNameDescending();
            storageClient.Print();

            Console.WriteLine("SORT BY WEIGHT ASC");
            storage.SortProductsByKeySelectorAscending(p => p.Weight);
            storageClient.Print();

            Console.WriteLine("SORT BY WEIGHT DES");
            storage.SortProductsByKeySelectorDescending(p => p.Weight);
            storageClient.Print();

            Console.WriteLine(new String('-', 10));
        }
    }
}