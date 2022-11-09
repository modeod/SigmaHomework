using SigmaHomework_5_Task1.ProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_5_Task1.StorageEcosystem
{
    public class StorageItem : ICloneable
    {
        private ProductModel _product;
        private uint _amount;

        public ProductModel Product
        {
            get => _product;
            set => _product = value;
        }

        public uint Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public StorageItem(ProductModel product, uint amount = 1)
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
            return $"[STORAGE ITEM] Product {_product.Name}: amount {_amount} (Total price = {CalculateTheSum()} {_product.Courency}.)";
        }

        public object Clone()
        {
            StorageItem item = (StorageItem)this.MemberwiseClone();
            item.Product = (ProductModel)this.Product.Clone();
            return item;
        }
    }
}
