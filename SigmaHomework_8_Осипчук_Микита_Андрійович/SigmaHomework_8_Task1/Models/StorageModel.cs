using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_8_Task1.Models
{
    public class StorageModel
    {
        public Dictionary<string, int> StorageItems { get; }
        
        public StorageModel(Dictionary<string, int> storageItems)
        {
            StorageItems = storageItems;
        }

    }
}
