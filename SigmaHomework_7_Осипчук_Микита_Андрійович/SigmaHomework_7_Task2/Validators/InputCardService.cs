using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_7_Task2.Validators
{
    internal static class ConsoleHelper
    {
        public static string GetCardFromConsoleAndValidate()
        {
            Console.WriteLine("Enter card number:");
            while (true)
            {
                string? input = Console.ReadLine()?.Trim();
                if (input != null)
                    if(input.Length <= 16)
                        if (ulong.TryParse(input, out var card))
                            return card.ToString();

                Console.WriteLine("Card number is not in valid format. Example: 5555555555554444. Try again:");
            }
        }
    }
}
