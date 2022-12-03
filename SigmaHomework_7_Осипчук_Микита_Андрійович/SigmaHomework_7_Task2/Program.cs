using SigmaHomework_7_Task2.Luhn;
using SigmaHomework_7_Task2.Validators;

namespace SigmaHomework_7_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILuhnAlgorithm luhn = new LuhnAlgorithm();
            IValidator[] validators = new IValidator[]
            {
                new ValidatorAmericanExpress(luhn),
                new ValidatorMasterCard(luhn),
                new ValidatorVisa(luhn)
            };

            while (true)
            {
                string inputString = ConsoleHelper.GetCardFromConsoleAndValidate();
                byte[] cardNumber = inputString
                    .Select(num => byte.Parse(num.ToString()))
                    .ToArray();

                (bool Valid, CardBrand Company) result = (false, CardBrand.MasterCard);

                foreach (var validator in validators)
                {
                    result = validator.Validate(cardNumber);
                    if (result.Valid)
                    {
                        Console.WriteLine("VALID, " + result.Company.ToString());
                        break;
                    }
                }

                if (!result.Valid)
                    Console.WriteLine("INVALID");
            }
        }
    }
}