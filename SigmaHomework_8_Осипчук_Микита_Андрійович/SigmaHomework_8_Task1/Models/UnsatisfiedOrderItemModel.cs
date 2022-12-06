using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_8_Task1.Models
{
    public  class UnsatisfiedOrderItemModel
    {
        public UnsatisfiedOrderItemModel(string productName, string company, uint amount, uint unsatisfiedAmount)
        {
            ProductName = productName;
            Company = company;
            Amount = amount;
            UnsatisfiedAmount = unsatisfiedAmount;
        }

        public string ProductName { get; set; }

        public string Company { get; set; }

        public uint Amount { get; set; }

        public uint UnsatisfiedAmount { get; set; }
    }
}
