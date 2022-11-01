using System.Text;

namespace SigmaHomework1_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Hello, World!");

            Check check = new Check();

            Product productKitten = new("Kitten", 20M, 3.5F);
            Product productBob = new("Bob", 4000.56M, 72.4F);

            Buy buyKittens = new(productKitten, 6);
            Buy buyBobs = new(productBob, 2);

            Cart cart = new Cart(buyKittens, buyBobs);

            check.Print(productKitten);
            check.Print(buyKittens);
            check.Print(productBob);
            check.Print(buyBobs);

            Console.WriteLine(new String('-', 10));

            check.Print(cart);
        }
    }
}