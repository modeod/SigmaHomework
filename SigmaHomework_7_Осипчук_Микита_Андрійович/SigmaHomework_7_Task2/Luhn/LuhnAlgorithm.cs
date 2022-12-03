using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_7_Task2.Validators;

namespace SigmaHomework_7_Task2.Luhn
{
    public class LuhnAlgorithm : ILuhnAlgorithm
    {
        public bool CheckSumValidate(byte[] cardNumber)
        {
            int result = 0;
            bool isEven = true;
            if (cardNumber.Length % 2 != 0)
                isEven = false;

            for (int i = (isEven? 0 : 1); i < cardNumber.Length; i += 2)
            {
                byte debugResult = (byte)(cardNumber[i] * 2);

                if (debugResult > 9)
                    debugResult = (byte)(debugResult % 10 + 1);

                result += debugResult;
            }

            for (int i = (isEven ? 1 : 0); i < cardNumber.Length; i+=2)
                result += cardNumber[i];

            if (result % 10 == 0)
                return true;
            return false;
        }
    }
}
