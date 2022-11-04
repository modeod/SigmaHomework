using SigmaHomework_3_Task1.ProductsModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_3_Task1
{
    public class Storage : IStorage
    {
        private readonly List<ProductModel> _products;

        public List<ProductModel> Products { get => _products; } // Не згоден з тим, що нам потрібно повертати копію ліста

        public ProductModel this[int index]
        {
            get => _products[index];
            set => _products[index] = value;
        }

        public Storage(List<ProductModel> products) => _products = products;
        public Storage(params ProductModel[] products) => _products = products.ToList();

        public Storage ChangePriceByOnlyPercentages(int percentage)
        {
            if (percentage < -100)
                throw new ArgumentOutOfRangeException("Percentages can not be lower than -100");

            _products.ForEach(product => product.ChangePriceByOnlyPercentages(percentage));

            return this;
        }

        public List<MeatModel> FindMeatInStorage()
        {
            List<MeatModel> meats = new();

            _products.ForEach(product =>
            {
                if (product is MeatModel meat)
                    meats.Add(meat);
            });

            return meats;
        }
    }
}
