using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_7_Task2.Luhn;

namespace SigmaHomework_7_Task2.Validators
{
    public class ValidatorMasterCard : IValidator
    {
        private readonly ILuhnAlgorithm _luhnAlgorithm;
        private const CardBrand _cardBrand = CardBrand.MasterCard;

        public ValidatorMasterCard(ILuhnAlgorithm luhnAlgorithm)
        {
            _luhnAlgorithm = luhnAlgorithm;
        }

        public (bool, CardBrand) Validate(byte[] cardNumber)
        {
            if(cardNumber.Length != 16)
                return (false, _cardBrand);

            if (cardNumber[0] != 5 || cardNumber[1] > 5 || cardNumber[1] < 1)
                return (false, _cardBrand);

            return (_luhnAlgorithm.CheckSumValidate(cardNumber), _cardBrand);
        }
    }
}
