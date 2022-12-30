using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_12_Task1.Models;

namespace SigmaHomework_12_Task1
{
    public delegate void PersonDoneEventHandler(object source, PersonDoneEventArgs arguments);

    public class Cashier
    {
        public event PersonDoneEventHandler PersonDoneEvent;

        public Guid Id { get; }
        public Point Point { get; protected set; }
        public uint MaxPersonsAnount { get; protected set; }
        public List<Status> StatusesAllowed { get; protected set; }

        private readonly LinkedList<PersonModel> _personsInQueue;
        //private readonly Queue<PersonModel> _persons;

        private Task? _currentTask;
        private CancellationTokenSource? cts;

        public Cashier(Guid id, Point point, uint maxPersonsAnount)
        {
            Id = id;
            Point = point;
            MaxPersonsAnount = maxPersonsAnount;
            _personsInQueue = new LinkedList<PersonModel>();
            StatusesAllowed = new List<Status>() { Status.Ordinary, Status.Veteran, Status.Elderly, Status.Disabled };
        }

        public void StartCashier()
        {
            cts = new CancellationTokenSource();

            _currentTask = Task.Run(async () =>
            {
                while (true)
                {
                    DoSomeStuffWithFirstPersonAndDequeue();
                    await Task.Delay(2_000, cts.Token);
                }
            });
        }

        public List<PersonModel> StopCashier()
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
            PersonDoneEvent = delegate { };

            Console.WriteLine($"DEBUG: Cashier {Id} Stopped");

            return GetPersonsInQueue();
        }

        public void AddPersonToQueue(PersonModel person)
        {
            lock (_personsInQueue)
                _personsInQueue.AddLast(person);
        }

        public void AddPersonToQueue(PersonModel[] person)
        {
            for (int i = 0; i < person.Length; i++)
                AddPersonToQueue(person[i]);
        }

        public void AddPersonToQueueByStatus(PersonModel personToAdd)
        {
            if (_personsInQueue.First == null || _personsInQueue.Last?.Value.Status >= personToAdd.Status)
                _personsInQueue.AddLast(personToAdd);

            for (LinkedListNode<PersonModel>? iNode = _personsInQueue.First; iNode != null; iNode = iNode.Next)
            {
                if (iNode.Value.Status < personToAdd.Status)
                {
                    _personsInQueue.AddBefore(iNode, personToAdd);
                    break;
                }
            }
        }

        private void DoSomeStuffWithFirstPersonAndDequeue()
        {
            if (_personsInQueue.Count > 0)
            {
                var person = _personsInQueue.First();
                // do some stuff

                lock (_personsInQueue)
                    _personsInQueue.RemoveFirst();

                OnPersonDone(person);
                Console.WriteLine($"DEBUG: Cashier {Id} DoneSomeStuff. Persons left: " + _personsInQueue.Count);
            }
            else
            {
                Console.WriteLine($"DEBUG: Cashier {Id} " + _personsInQueue.Count + " persons Left");
            }
        }

        public List<PersonModel> GetPersonsInQueue()
        {
            //TODO: do we need copy? 
            return _personsInQueue.ToList();
        }

        public uint GetAmountOfPersonsInQueue()
        {
            return (uint)_personsInQueue.Count;
        }

        public virtual void OnPersonDone(PersonModel person)
        {
            PersonDoneEvent?.Invoke(this, new PersonDoneEventArgs() { Person = person });
        }

        public virtual void Subsribe()
    }
}
