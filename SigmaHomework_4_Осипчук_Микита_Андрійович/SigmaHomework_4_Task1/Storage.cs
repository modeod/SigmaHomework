using SigmaHomework_4_Task1.ProductsModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_4_Task1
{
    public class Storage
    {
        private readonly List<ProductModel> _products;  

        public List<ProductModel> Products { get => _products; } 
        //  4та домашка робилася на базі 3ї, а не на базі 5ї, тому тут все залишилось у старому вигляді,
        //бо її дедлайн був пізніше, ніж у 5ї

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

            _products.ForEach(product => {
                if (product is MeatModel meat)
                    meats.Add(meat);
            });

            return meats;
        }

        public Storage SortProductsByIdAscending()
        {
            _products.Sort();
            return this;
        }

        public Storage SortProductsByNameAscending()
        {
            _products.Sort(ProductModel.SortByNameAscending());
            return this;
        }

        public Storage SortProductsByNameDescending()
        {
            _products.Sort(ProductModel.SortByNameDescending());
            return this;
        }

        public Storage SortProductsByKeySelectorAscending<TKey>(Func<ProductModel, TKey> selector) // Обертка над ордерБай?
        {
            List<ProductModel> collection = _products.OrderBy(selector).ToList();// debug
            _products.Clear();
            _products.AddRange(collection);
            return this;
        }

        public Storage SortProductsByKeySelectorDescending<TKey>(Func<ProductModel, TKey> selector) // Обертка над ордерБай?
        {
            List<ProductModel> collection = _products.OrderByDescending(selector).ToList(); // debug
            _products.Clear();
            _products.AddRange(collection);
            return this;
        }
    }
}
