using SigmaHomework_9_Task1.Services;

namespace SigmaHomework_9_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            /* Array = 1 4 2 12 | 8 3 16 10 || 20 0 22 5, MAX INPUT = 8
             * 1 файл после слияния: 4(max/2) - 1 2 4 12
             * 2 файл после слияния: 4 - 3 8 10 16
             * 3 файл после слияния: 4 - 0 5 20 22
             * 
             * 
             * Пишем сортировку галлопом по сортированным файлам
             */
            MergeSortingService mergeService = new MergeSortingService();
            int[] testArray = { 1, 4, 2, 7, 22, 5, 122, -4, 5, 9};
            mergeService.MergeSort(testArray);
            testArray.ToList().ForEach(num => Console.Write(num + ", "));

            Console.ReadKey();
        }
    }
}