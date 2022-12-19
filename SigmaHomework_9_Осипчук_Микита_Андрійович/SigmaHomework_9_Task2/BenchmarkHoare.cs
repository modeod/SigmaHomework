using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using Bogus;
using SigmaHomework_9_Task2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_9_Task2
{
    [RankColumn]
    public class BenchmarkHoare
    {
        [Benchmark]
        public ProductModel[] HoareFirstPivot()
        {
            GetPivotLogic<ProductModel> firstPivot = (ProductModel[] arr, int left, int right) =>
                arr[left];

            var faker = new Faker<ProductModel>()
                .RuleFor(prod => prod.Name, f => f.Commerce.Product())
                .RuleFor(prod => prod.Price, f => decimal.Parse(f.Commerce.Price()));

            var products1 = faker.Generate(70).ToArray();

            HoareQuickSortProductModel hoareQuickSort = new();
            //hoareQuickSort.QuickSortHoara(products1, firstPivot);
            // Чому ти блять не хочешь запускати цей метод, а партОвСорт метод спокійно бенчмариш, я ось просто не пойму блять, що за діч
            hoareQuickSort.PartOfSortHoara(products1, 0, products1.Length - 1, firstPivot);
            return products1;

        }
    }
}
