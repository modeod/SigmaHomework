using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_4_Task1.ProductsModels;

namespace SigmaHomework_4_Task1
{
    public class Check
    {
        

        public void Print(Buy buy)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(buy);
            Console.ResetColor();
        }

        public void Print(ProductModel product)
        {
            Console.WriteLine(product);
        }
    }
}
