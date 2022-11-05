using SigmaHomework_4_Task1.Enums;
using SigmaHomework_4_Task1.ProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_4_Task1.ProductFactories
{
    public class ProductFactory : IProductFactory
    {
        public virtual ProductModel Create()
        {
            string nameAnswer;
            decimal priceAnswer;
            float weightAnswer;
            int answer;

            nameAnswer = ConsoleAnswers.GetAnswer("Enter product name: ");

            string[] courenciesTypesStr = Enum.GetNames(typeof(Courency));
            answer = ConsoleAnswers.GetIndexAnswerByArray(courenciesTypesStr.ToList(), "Enter number of Courency: ");
            Courency courency = (Courency)Enum.Parse(typeof(Courency), courenciesTypesStr[answer]);

            priceAnswer = ConsoleAnswers.GetAnswerAndParse<decimal>($"Enter price ({courenciesTypesStr[answer]}): ", (string s) => decimal.Parse(s), (num) => num >= 0);
            weightAnswer = ConsoleAnswers.GetAnswerAndParse<float>("Enter weight: ", (string s) => float.Parse(s), (num) => num > 0);

            return new ProductModel(nameAnswer, priceAnswer, weightAnswer, courency);
        }
    }
}
