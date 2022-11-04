using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_3_Task1.Enums;

namespace SigmaHomework_3_Task1
{
    public class Cart //TODO: Add indexator
    {
        private readonly List<Buy> _products;
        
        public List<Buy> Products { get { return _products; } }

        public Buy this[int index]
        {
            get => _products[index];
            set => _products[index] = value;
        }

        public Cart()
        {
            _products = new List<Buy>();
        }

        public Cart(params Buy[] buys) : this()
        {
            _products = buys.ToList();
        }

        public decimal SumPrice()
        {
            return _products.Sum(buy => 
            {
                return buy.CalculateTheSum();
            });
        }

        public float SumWeight()
        {
            float totalWeight = 0;
            for (int i = 0; i < _products.Count; i++)
            {
                totalWeight += _products[i].Product.Weight;
            }

            return totalWeight;
        }

        public uint CountProducts()
        {
            return (uint)_products.Sum(p => p.Amount);
        }

        public uint CountBuys()
        {
            return (uint)_products.Count();
        }
    }
}
