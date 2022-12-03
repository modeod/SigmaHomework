using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_7_Task1.Enums;

namespace SigmaHomework_7_Task1
{
    public class Cart //TODO: Add indexator
    {
        private readonly List<Buy> _products;
        
        public Courency Courency { get; set; }

        public List<Buy> Products { get { return _products; } }

        public Buy this[int index]
        {
            get => _products[index];
            set => _products[index] = value;
        }

        public Cart(Courency сourency)
        {
            _products = new List<Buy>();
            Courency = сourency;
        }

        public Cart(Courency сourency, params Buy[] buys) : this(сourency)
        {
            _products = buys.ToList();
        }

        public decimal SumPrice()
        {
            return _products.Sum(buy => 
            {
                if (buy.Product.Courency != this.Courency)
                {
                    return CourencyExchanger.ExchangeCourency(buy.Product.Courency, this.Courency, buy.CalculateTheSum());
                }

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
