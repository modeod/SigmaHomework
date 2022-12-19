using Bogus;
using SigmaHomework_9_Task2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_9_Task2
{
    public class HandmadeHoaraBenchmarkFU
    {

        public void BenchmarkHoara(GetPivotLogic<ProductModel>[] pivotLogicsToBenchmark)
        {
            HoareQuickSort<ProductModel> hoareQuickSort = new HoareQuickSort<ProductModel>();
            var faker = new Faker<ProductModel>()
                .RuleFor(prod => prod.Name, f => f.Commerce.Product())
                .RuleFor(prod => prod.Price, f => decimal.Parse(f.Commerce.Price()));

            var productsToWarm = faker.Generate(1).ToArray();
            hoareQuickSort.QuickSortHoara(productsToWarm, (ProductModel[] arr, int left, int right) => arr[left]);

            for (int i = 0; i < pivotLogicsToBenchmark.Length; i++)
            {
                var products = faker.Generate(2).ToArray();
                Stopwatch sw = new Stopwatch();
                sw.Start();
                hoareQuickSort.QuickSortHoara(products, pivotLogicsToBenchmark[i]);
                sw.Stop();
                Console.WriteLine("Time elapsed (ns): {0}", sw.Elapsed.TotalMilliseconds * 1000000);
            }
        }
    }
}
