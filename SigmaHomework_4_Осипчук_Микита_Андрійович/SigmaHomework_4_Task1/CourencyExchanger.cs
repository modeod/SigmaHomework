using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_4_Task1.Enums;

namespace SigmaHomework_4_Task1
{
    public static class CourencyExchanger
    {
        private static decimal[,] _courencyTable = new decimal[3, 3]
            {
                {1M, 1/27M, 1/32M },
                {27M, 1M, 0.9M },
                {32M, 1/0.9M, 1M }
            };

        public static decimal ExchangeCourency(Courency from, Courency to, decimal sum)
        {
            return _courencyTable[(int)from, (int)to] * sum;
        }
    }
}
