using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_12_Task1.Interfaces;
using SigmaHomework_12_Task1.Models;
using SigmaHomework_12_Task1.Services;

namespace SigmaHomework_12_Task1
{
    internal class Shop
    {
        private Task? _currentTask;
        private CancellationTokenSource? cts;
        private readonly IPersonsGenerator _personsGenerator;
        private readonly IPersonsFileHandler _personFileHandler;

        protected Dictionary<Guid, Cashier> Cashiers { get; }

        protected Queue<PersonModel> PersonsInShop { get; set; }

        public Shop(IPersonsGenerator personsGenerator, IPersonsFileHandler personFileHandler)
        {
            Cashiers = new Dictionary<Guid, Cashier>();
            PersonsInShop = new Queue<PersonModel>();
            _personsGenerator = personsGenerator;
            _personFileHandler = personFileHandler; 
        }

        public void StartSimulator()
        {
            var persons = _personsGenerator.GeneratePersons(40);
            _personFileHandler.WritePersonsToJSON(persons);

            AddCashier(new Cashier(Guid.NewGuid(),
                new Point(20, 10),
                50));
            AddCashier(new Cashier(Guid.NewGuid(),
                new Point(50, 10),
                50));
            AddCashier(new Cashier(Guid.NewGuid(),
                new Point(80, 10),
                50));

            //foreach (var cashier in Cashiers.Values)
            //    cashier.StartCashier();

            cts = new CancellationTokenSource();

            _currentTask = Task.Run(async () =>
            {
                while (true)
                {
                    CashierAlgorythm();
                    await Task.Delay(5_000, cts.Token);
                }
            });
        }

        public void Stop()
        {
            using (cts)
                cts?.Cancel();

            try
            {
                _currentTask?.Wait();
            }
            catch (AggregateException) { }

            cts = null;
            _currentTask = null;
            Console.WriteLine($"DEBUG: Shop Stopped");
        }

        private void CashierAlgorythm()
        {
            var personsFromFile = _personFileHandler.ReadPersonsFromJSON();
            if (personsFromFile == null)
                return;

            AddPersonsToShop(personsFromFile);

            while (PersonsInShop.Count > 0)
            {
                var person = PersonsInShop.Dequeue();

                List<Cashier> cashiersLowestByAmount = new List<Cashier>();

                cashiersLowestByAmount.Add(Cashiers.First().Value);
                double lowestAmountOfPeople = Cashiers.First().Value.GetAmountOfPersonsInQueue();

                foreach (var currentCashier in Cashiers.Values) //Refactor to values
                {
                    if (!currentCashier.StatusesAllowed.Contains(person.Status))
                        continue;

                    if (currentCashier.GetAmountOfPersonsInQueue() < lowestAmountOfPeople)
                    {
                        cashiersLowestByAmount.Clear();
                        lowestAmountOfPeople = currentCashier.GetAmountOfPersonsInQueue();
                        cashiersLowestByAmount.Add(currentCashier);
                        continue;
                    }

                    if (currentCashier.GetAmountOfPersonsInQueue() == lowestAmountOfPeople)
                        cashiersLowestByAmount.Add(currentCashier);
                }

                if (cashiersLowestByAmount.Count > 1)
                {
                    Cashier shortestDisCash = cashiersLowestByAmount[0];
                    double shortestDistance = CalculateDistance(person.CurrentPosition, shortestDisCash.Point);

                    foreach (var cash in cashiersLowestByAmount)
                    {
                        double currDistance = CalculateDistance(person.CurrentPosition, shortestDisCash.Point);
                        if (shortestDistance > currDistance)
                        {
                            shortestDisCash = cash;
                            shortestDistance = currDistance;
                        }
                    }

                    shortestDisCash.AddPersonToQueueByStatus(person);

                    Console.WriteLine("DEBUG: Shop Added person to Queue by Distance");
                    continue;
                }

                Console.WriteLine("DEBUG: Shop Added person to Queue by NUMBER OF QUEUE");
                cashiersLowestByAmount[0].AddPersonToQueueByStatus(person);
            }
        }

        public void AddPersonsToShop(PersonModel[] persons)
        {
            for (int i = 0; i < persons.Length; i++)
                AddPersonToShop(persons[i]);
        }

        public void AddPersonToShop(PersonModel person)
        {
            lock (PersonsInShop)
                PersonsInShop.Enqueue(person);
        }

        public void AddCashier(Cashier model)
        {
            lock(Cashiers)
                Cashiers.Add(model.Id, model);
        }

        public void DeleteCashier(Guid cashierId)
        {
            lock (Cashiers)
            {
                if (Cashiers.TryGetValue(cashierId, out Cashier? cashier))
                {
                    if (cashier != null)
                    {
                        lock (PersonsInShop)
                            foreach (var person in cashier.GetPersonsInQueue())
                                PersonsInShop.Enqueue(person);

                        cashier.GetPersonsInQueue().Clear(); //Idk if we need it here
                    }
                }

                Cashiers.Remove(cashierId);
            }
        }

        public double CalculateDistance(Point person, Point cashier)
        {
            double a = Math.Pow((cashier.X - person.X), 2);
            double b = Math.Pow((cashier.Y - person.Y), 2);
            double res = Math.Sqrt(a + b);
            return res;
        }
    }
}
