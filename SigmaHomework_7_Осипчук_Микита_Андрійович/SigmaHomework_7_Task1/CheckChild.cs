using SigmaHomework_7_Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_7_Task1
{
    public class CheckChild : Check
    {
        public void Print(Cart cart)
        {
            Console.WriteLine("CART:");
            cart.Products.ForEach(x => Print(x)); // Stringbuilder?
            Console.WriteLine("TOTAL PRICE = " + cart.SumPrice() + " " + cart.Courency);
        }
    }
}
