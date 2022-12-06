using SigmaHomework_8_Task1.Models;
using SigmaHomework_8_Task1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_8_Task1.Services
{
    public class StorageService : IStorageService
    {

        public StorageModel GetStorage()
        {
            // Logic for getting storage. For example HTTP request to storage WepApi or using RabbitMQ
            // For now just simulating it as Microservice

            return new StorageModel(new Dictionary<string, int>()
            {
                {"Donuts", 20 },
                {"Frozen developers", 2 },
                {"Tea bags", 255 },
                {"Coffee", 8 }
            });
        }
    }
}
