using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_7_Task2.Luhn;

namespace SigmaHomework_7_Task2.Validators
{
    public class ValidatorVisa : IValidator
    {
        private readonly ILuhnAlgorithm _luhnAlgorithm;
        private const CardBrand _cardBrand = CardBrand.Visa;

        public ValidatorVisa(ILuhnAlgorithm luhnAlgorithm)
        {
            _luhnAlgorithm = luhnAlgorithm;
        }

        public (bool, CardBrand) Validate(byte[] cardNumber)
        {
            if (cardNumber.Length != 13 && cardNumber.Length != 16 &&
                cardNumber[0] != 4)
                return (false, _cardBrand);

            return (_luhnAlgorithm.CheckSumValidate(cardNumber), _cardBrand);
        }
    }
}
