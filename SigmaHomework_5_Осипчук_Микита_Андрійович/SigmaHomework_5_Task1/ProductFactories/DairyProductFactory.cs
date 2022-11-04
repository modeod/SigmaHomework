using SigmaHomework_5_Task1.Enums;
using SigmaHomework_5_Task1.ProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_5_Task1.ProductFactories
{
    public class DairyProductFactory : ProductFactory
    {
        public override ProductModel Create()
        {
            var product = base.Create();

            int expirationDateInDaysAnswer = ConsoleAnswers.GetAnswerAndParse<int>("Enter expiration date in days: ", (string s) => int.Parse(s), (num) => num > 0);
            DateTime manufacturingDateAnswer = ConsoleAnswers.GetAnswerAndParse<DateTime>(
                $"Enter manufacturing date (Example: {default(DateTime)}): ",
                (string s) => DateTime.Parse(s), (manufacturingDate) => manufacturingDate < DateTime.Now);

            return new DairyProductModel(product.Name, expirationDateInDaysAnswer, manufacturingDateAnswer, product.Price, product.Weight, product.Courency);
        }
    }
}
