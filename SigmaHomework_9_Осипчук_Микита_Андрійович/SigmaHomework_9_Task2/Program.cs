using Bogus;
using SigmaHomework_9_Task2.Models;
using System.Text;

namespace SigmaHomework_9_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Hello, World!");

            var faker = new Faker<ProductModel>()
                .RuleFor(prod => prod.Name, f => f.Commerce.Product())
                .RuleFor(prod => prod.Price, f => decimal.Parse(f.Commerce.Price()));

            var products1 = faker.Generate(70).ToArray();
            var products2 = faker.Generate(70).ToArray();
            var products3 = faker.Generate(70).ToArray();

            HoareQuickSort<ProductModel> hoareQuickSort = new();
            GetPivotLogic<ProductModel> firstPivot = (ProductModel[] arr, int left, int right) =>
                arr[left];
            GetPivotLogic<ProductModel> middlePivot = (ProductModel[] arr, int left, int right) =>
                arr[(left + right) / 2];
            GetPivotLogic<ProductModel> lastPivot = (ProductModel[] arr, int left, int right) =>
                arr[right];


            Console.WriteLine("\n ========= INPUT ARRAY: ");
            Console.WriteLine(String.Join<ProductModel>('\n', products1));
            Console.WriteLine("\n ========= RESULT: ");
            hoareQuickSort.QuickSortHoara(products1, lastPivot);
            Console.WriteLine(String.Join<ProductModel>('\n', products1));

            Console.ReadKey();
        }
    }
}