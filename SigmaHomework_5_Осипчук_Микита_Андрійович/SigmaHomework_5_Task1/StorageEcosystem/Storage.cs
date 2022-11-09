using SigmaHomework_5_Task1.ProductsModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_5_Task1.StorageEcosystem
{
    public class Storage
    {
        public delegate void AddedItemHandler(StorageItem updatedItem, uint amount);
        public event AddedItemHandler? AddedItemNotify;

        public delegate void UpdatedItemHandler(ProductModel updatedItem, ProductModel oldItem);
        public event UpdatedItemHandler? UpdatedItemNotify;

        public delegate void RemovedItemHandler(StorageItem updatedItem, uint amount);
        public event RemovedItemHandler? RemovedItemNotify;

        private readonly List<StorageItem> _products;

        public ReadOnlyCollection<StorageItem> Products { get => new ReadOnlyCollection<StorageItem>(_products); } 

        public StorageItem this[int index]
        {
            get => (StorageItem)_products[index].Clone();
            set
            {
                StorageItem item = _products[index];

                UpdatedItemNotify?.Invoke((ProductModel)value.Clone(), (ProductModel)item.Clone());
                item.Product = (ProductModel)value.Clone();
            }
        }

        public StorageItem? this[ProductModel model]
        {
            get => (StorageItem?)_products.FirstOrDefault(item => model.Equals(item.Product))?.Clone();
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));

                StorageItem? item = _products.FirstOrDefault(item => model.Equals(item.Product));
                if (item == null)
                    throw new KeyNotFoundException();

                UpdatedItemNotify?.Invoke((ProductModel)value.Clone(), (ProductModel)item.Clone());

                item.Product = (ProductModel)value.Clone();
            }
        }

        public Storage(List<StorageItem> products) => _products = products;
        public Storage(params StorageItem[] products) => _products = products.ToList();

        public void ChangePriceByOnlyPercentages(int percentage)
        {
            if (percentage < -100)
                throw new ArgumentOutOfRangeException("Percentages can not be lower than -100");

            _products.ForEach(product => product.Product.ChangePriceByOnlyPercentages(percentage));
        }

        public ReadOnlyCollection<StorageItem> FindMeatInStorage()
        {
            List<StorageItem> meats = new();

            _products.ForEach(product =>
            {
                if (product.Product is MeatModel meat)
                    meats.Add((StorageItem)product.Clone());
            });

            return meats.AsReadOnly();
        }

        public StorageItem AddItem(ProductModel product, uint amount = 1)
        {
            StorageItem? item = _products.FirstOrDefault(item => product.Equals(item.Product));
            if (item == null)
            {
                item = new StorageItem((ProductModel)product.Clone(), amount);
                _products.Add(item);
            }
            else
                item.Amount += amount;

            AddedItemNotify?.Invoke((StorageItem)item.Clone(), amount);

            return (StorageItem)item.Clone();
        }

        public StorageItem UpdateItemInformation(ProductModel toUpdate, ProductModel updatedProduct)
        {
            StorageItem? item = _products.FirstOrDefault(item => toUpdate.Equals(item.Product));
            if (item == null)
                throw new KeyNotFoundException();

            item.Product = (ProductModel)updatedProduct.Clone();
            UpdatedItemNotify?.Invoke((ProductModel)toUpdate.Clone(), (ProductModel)updatedProduct.Clone());

            return (StorageItem)item.Clone();
        }

        public StorageItem DeleteItem(ProductModel product, uint amount)
        {
            StorageItem? item = _products.FirstOrDefault(item => product.Equals(item.Product));
            if(item == null)
                throw new KeyNotFoundException();

            if(amount >= item.Amount)
                _products.Remove(item);
            else
                item.Amount -= amount;

            RemovedItemNotify?.Invoke((StorageItem)item.Clone(), amount);

            return (StorageItem)item.Clone();
        }
    }
}
