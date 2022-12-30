using SigmaHomework_12_Task1.Interfaces;
using SigmaHomework_12_Task1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_12_Task1.Services
{
    public class LoggerService
    {
        private readonly IFileHandler _fileHandler;

        private Task? _currentTask;
        private CancellationTokenSource? cts;

        Queue<(Cashier source, PersonDoneEventArgs arguments)> _cashierToLoggingData;

        public LoggerService(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
            _cashierToLoggingData = new Queue<(Cashier source, PersonDoneEventArgs arguments)>();
        }

        public void OnCashierPeopleDone(object source, PersonDoneEventArgs arguments)
        {
            lock(_cashierToLoggingData)
                _cashierToLoggingData.Enqueue(((Cashier)source, arguments));

        }

        public void StartLogger()
        {
            cts = new CancellationTokenSource();

            _currentTask = Task.Run(async () =>
            {
                while (true)
                {
                    LogCashier();
                    await Task.Delay(100, cts.Token);
                }
            });
        }

        public void StopLogger()
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

            Console.WriteLine($"DEBUG: Logger Stopped");
        }

        public void LogCashier()
        {
            (Cashier cashier, PersonDoneEventArgs arguments)? toLog = null;

            lock (_cashierToLoggingData)
            {
                if(_cashierToLoggingData.Count > 0)
                    toLog = _cashierToLoggingData.Dequeue();
            }

            if(toLog != null)
                _fileHandler.Write($"[Cashier {toLog.Value.cashier.Id}, {DateTime.Now}]: Person {toLog.Value.arguments.Person.Name} has done;");
        }

    }
}
