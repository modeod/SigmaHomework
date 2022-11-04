using SigmaHomework_3_Task1.Enums;
using SigmaHomework_3_Task1.ProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_3_Task1.ProductFactories
{
    public class MeatFactory : ProductFactory
    {
        public override ProductModel Create()
        {
            var product = base.Create();

            int answer;
            MeatType meatTypeAnswer;
            MeatCategory meatCategoryAnswer;

            string[] meatTypesStr = Enum.GetNames(typeof(MeatType));
            string[] meatCategoryStr = Enum.GetNames(typeof(MeatCategory));

            answer = ConsoleAnswers.GetIndexAnswerByArray(meatTypesStr.ToList(), "Enter number of meat type: ");
            meatTypeAnswer = (MeatType)Enum.Parse(typeof(MeatType), meatTypesStr[answer]);
            answer = ConsoleAnswers.GetIndexAnswerByArray(meatCategoryStr.ToList(), "Enter number of meat category: ");
            meatCategoryAnswer = (MeatCategory)Enum.Parse(typeof(MeatCategory), meatCategoryStr[answer]);

            return new MeatModel(product.Name, product.Price, product.Weight, meatTypeAnswer, meatCategoryAnswer);
        }
    }
}
