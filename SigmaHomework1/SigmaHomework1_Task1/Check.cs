using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework1_Task1
{
    public class Check
    {
        public void Print(Cart cart)
        {
            Console.WriteLine("CART:");
            cart.Products.ForEach(x => Print(x)); // Stringbuilder?
        }

        public void Print(Buy buy)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(buy);
            Console.ResetColor();
        }

        public void Print(Product product)
        {
            Console.WriteLine(product);
        }
    }
}
