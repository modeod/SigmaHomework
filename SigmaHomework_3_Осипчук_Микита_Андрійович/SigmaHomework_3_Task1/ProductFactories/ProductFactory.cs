using SigmaHomework_3_Task1.Enums;
using SigmaHomework_3_Task1.ProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_3_Task1.ProductFactories
{
    public class ProductFactory : IProductFactory
    {
        public virtual ProductModel Create()
        {
            string nameAnswer;
            decimal priceAnswer;
            float weightAnswer;

            nameAnswer = ConsoleAnswers.GetAnswer("Enter product name: ");
            priceAnswer = ConsoleAnswers.GetAnswerAndParse<decimal>($"Enter price: ", (string s) => decimal.Parse(s), (num) => num > 0);
            weightAnswer = ConsoleAnswers.GetAnswerAndParse<float>("Enter weight: ", (string s) => float.Parse(s), (num) => num > 0);

            return new ProductModel(nameAnswer, priceAnswer, weightAnswer);
        }
    }
}
