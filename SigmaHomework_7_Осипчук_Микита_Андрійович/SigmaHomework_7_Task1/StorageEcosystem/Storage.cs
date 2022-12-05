using SigmaHomework_7_Task1.ProductsModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_7_Task1.StorageEcosystem
{
    public delegate void AddedItemHandler(StorageItem updatedItem, uint amount);
    public delegate void UpdatedProductInfoHandler(ProductModel updatedItem, ProductModel oldItem);
    public delegate void UpdatedItemHandler(StorageItem updatedItem, StorageItem oldItem);
    public delegate void RemovedItemHandler(StorageItem updatedItem, uint amount);

    public class Storage
    {
        public event AddedItemHandler? AddedItemNotify;

        public event UpdatedProductInfoHandler? UpdatedProductInfoNotify;

        public event UpdatedItemHandler? UpdatedItemNotify;

        public event RemovedItemHandler? RemovedItemNotify;

        private readonly List<StorageItem> _products;

        public List<StorageItem> Products { get => _products; }

        public StorageItem this[int index]
        {
            get => (StorageItem)_products[index].Clone();
            set
            {
                if (value == null)
                    throw new NullReferenceException(nameof(value));

                StorageItem item = _products[index];

                _products[index] = (StorageItem)value.Clone();
                UpdatedItemNotify?.Invoke((StorageItem)value.Clone(), (StorageItem)item.Clone());
            }
        }

        public StorageItem? this[ProductModel model]
        {
            get => (StorageItem?)_products.FirstOrDefault(item => model.Equals(item.Product))?.Clone();
            set
            {
                if (value == null)
                    throw new NullReferenceException(nameof(value));

                int itemIndex = _products.FindIndex(item => model.Equals(item.Product));
                if (itemIndex == -1)
                    throw new KeyNotFoundException(nameof(value));

                StorageItem item = _products[itemIndex];

                _products[itemIndex] = (StorageItem)value.Clone();
                UpdatedItemNotify?.Invoke((StorageItem)value.Clone(), (StorageItem)item.Clone());
            }
        }

        public Storage(List<StorageItem> products) => _products = products;
        public Storage(params StorageItem[] products) => _products = products.Distinct().ToList();

        public void ChangePriceByOnlyPercentages(int percentage)
        {
            if (percentage < -100)
                throw new ArgumentOutOfRangeException("Percentages can not be lower than -100");

            _products.ForEach(product => product.Product.ChangePriceByOnlyPercentages(percentage));
        }

        public List<StorageItem> FindMeatInStorage()
        {
            List<StorageItem> meats = new();

            _products.ForEach(product =>
            {
                if (product.Product is MeatModel meat)
                    meats.Add((StorageItem)product.Clone());
            });

            return meats;
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

        public StorageItem UpdateProductInformation(ProductModel toUpdate, ProductModel updatedProduct)
        {
            StorageItem? item = _products.FirstOrDefault(item => toUpdate.Equals(item.Product));
            if (item == null)
                throw new KeyNotFoundException();

            item.Product = (ProductModel)updatedProduct.Clone();
            UpdatedProductInfoNotify?.Invoke((ProductModel)toUpdate.Clone(), (ProductModel)updatedProduct.Clone());

            return (StorageItem)item.Clone();
        }

        public StorageItem DeleteItem(ProductModel product, uint amount)
        {
            StorageItem? item = _products.FirstOrDefault(item => product.Equals(item.Product));
            if (item == null)
                throw new KeyNotFoundException();

            if (amount >= item.Amount)
                _products.Remove(item);
            else
                item.Amount -= amount;

            RemovedItemNotify?.Invoke((StorageItem)item.Clone(), amount);

            return (StorageItem)item.Clone();
        }
        // ПОНЕДІЛОК Через обстріли відмінився.....
        // Технічно завдання виконано, але варіант з Лістом виявився неєєфективним (через О(N*M)). 
        // Тому у понеділок я зроблю рефакторінг усієї програми цієї. Та сторедж перейде на диктіонарі (щоб був  О(N))!
        // ПОНЕДІЛОК Через обстріли відмінився.....
        public List<StorageItem> GetProductsFirstStorageHaveAndSecondDont(Storage secondStorage)
        {
            List<StorageItem> items = new();

            foreach (var item in _products)
            {
                bool notFinded = true;
                foreach (var secondItem in secondStorage.Products)
                {
                    if (item.Product.Equals(secondItem.Product))
                    {
                        notFinded = false;
                        break; 
                    }
                }

                if(notFinded)
                    items.Add(item);
            }

            return items;
        }

        // b. Товари, які є спільними в обох складах.  (тобто список товарів, які є і там, і там)
        // c. Спільний список товарів, які є на обох складах, без повторів елементів. (тобто теж саме, що вище, бо я використовую стореджІтеми
        // що при додаванні однакового товару просто збільшують кількість (число) біля нього, а не додають новий стореджітем.

        public List<StorageItem> GetProductsInnerJoin(Storage secondStorage) =>
            _products.FindAll(prod => secondStorage.Products.Any(secondProd => secondProd.Product.Equals(prod.Product)));
    }
}
