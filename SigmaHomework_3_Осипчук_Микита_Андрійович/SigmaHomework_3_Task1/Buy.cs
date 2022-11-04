using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_3_Task1.ProductsModels;

namespace SigmaHomework_3_Task1
{
    public class Buy
    {
        //or use dictionary
        private ProductModel _product;
        private uint _amount;

        public ProductModel Product 
        { 
            get => (ProductModel)_product.Clone(); 
            set => _product = (ProductModel)value.Clone(); 
        }

        public uint Amount { get => _amount; set => _amount = value; }

        public Buy(ProductModel product, uint amount = 1)
        {
            _product = (ProductModel)product.Clone();
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
