using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_3_Task1.ProductsModels;

namespace SigmaHomework_3_Task1
{
    public class Check
    {
        public void Print(Cart cart)
        {
            Console.WriteLine("Print CART:");
            cart.Products.ForEach(x => Print(x)); // Stringbuilder?
        }

        public void Print(Buy buy)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Print BUY \n" + buy);
            Console.ResetColor();
        }

        public void Print(ProductModel product)
        {
            Console.WriteLine("Print PRODUCT: \n" + product);
        }
    }
}
