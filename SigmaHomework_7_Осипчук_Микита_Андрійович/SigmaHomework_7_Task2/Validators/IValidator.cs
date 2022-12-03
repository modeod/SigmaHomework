using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_7_Task2.Validators
{
    public interface IValidator
    {
        (bool, CardBrand) Validate(byte[] cardNumber);
    }
}
