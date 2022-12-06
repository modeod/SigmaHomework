using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_7_Task2.Luhn;

namespace SigmaHomework_7_Task2.Validators
{
    public class ValidatorAmericanExpress : IValidator
    {//не бачу потреби у окремих класах. Занадто дробити теж не добре.
        private readonly ILuhnAlgorithm _luhnAlgorithm;
        private const CardBrand _cardBrand = CardBrand.AmericanExpress;
// вважаю, що краще  валідувати стрічку.
        public ValidatorAmericanExpress(ILuhnAlgorithm luhnAlgorithm)
        {
            _luhnAlgorithm = luhnAlgorithm;
        }

        public (bool, CardBrand) Validate(byte[] cardNumber)
        {
            if (cardNumber.Length != 15)
                return (false, _cardBrand);

            if ( ! (cardNumber[0] == 3 && cardNumber[1] == 4 || cardNumber[0] == 3 && cardNumber[1] == 7))
                return (false, _cardBrand);

            return (_luhnAlgorithm.CheckSumValidate(cardNumber), _cardBrand);
        }
    }
}
