using SigmaHomework_12_Task1.Interfaces;
using SigmaHomework_12_Task1.Models;
using SigmaHomework_12_Task1.Services;
using System.Drawing;

namespace SigmaHomework_12_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            PersonsGenerator personsGenerator = new PersonsGenerator();
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string jsonPath = exeDir + "ShopPersons.json";
            IFileHandler fileHandler = new FileHandler(jsonPath, jsonPath);
            IPersonsFileHandler personsFile = new PersonsFileHandler(fileHandler);

            var persons = personsGenerator.GeneratePersons(5);
            personsFile.WritePersonsToJSON(persons);
            var personsFromJson = personsFile.ReadPersonsFromJSON();

            Shop shop = new Shop(personsGenerator, personsFile);
            //shop.StartSimulator();

            Console.ReadKey();

            //CashierModel c1 = new CashierModel(guid1, new Point(0, 10), 10);
            //foreach (var p in persons)
            //    c1.AddPersonToQueueByStatus(p);

            //c1.StartCashier();

            //Console.WriteLine("Start sleeping.");
            //Thread.Sleep(6000);
            //Console.WriteLine("Slept. Add persons");
            //persons = personsGenerator.GeneratePersons(5);
            //c1.AddPersonToQueue(persons);

            //Console.WriteLine("Start sleeping.");
            //Thread.Sleep(2000 * 9);
            //Console.WriteLine("Slept. Add persons");
            //persons = personsGenerator.GeneratePersons(5);
            //c1.AddPersonToQueue(persons);
            //Thread.Sleep(2000 * 2);
            //c1.StopCashier();
            //Console.ReadKey();
        }
    }
}