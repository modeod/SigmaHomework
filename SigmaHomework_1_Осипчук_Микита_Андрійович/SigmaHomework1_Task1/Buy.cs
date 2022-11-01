using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework1_Task1
{
    public class Buy
    {
        //or use dictionary
        private Product _product;
        private uint _amount;

        public Product Product 
        { 
            get => (Product)_product.Clone(); 
            set => _product = (Product)value.Clone(); 
        }

        public uint Amount { get => _amount; set => _amount = value; }

        public Buy(Product product, uint amount = 1)
        {
            _product = (Product)product.Clone();
            _amount = amount;
        }

        public decimal CalculateTheSum()
        {
            return Amount * Product.Price;
        }

        public override string ToString()
        {
            return $"[CART ITEM] Product {_product.Name}: amount {_amount} (Total price = {CalculateTheSum()} c.u.)";
        }
    }
}
