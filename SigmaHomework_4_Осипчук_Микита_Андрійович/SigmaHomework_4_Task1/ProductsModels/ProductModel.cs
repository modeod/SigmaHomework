using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_4_Task1.Enums;

namespace SigmaHomework_4_Task1.ProductsModels
{
    public class ProductModel : ICloneable, IComparable
    {
        private Guid _guid;
        private float _weight;
        private decimal _price;
        private Courency _courency;

        public string Name { get; set; }
        public Guid Guid { get => _guid; }
        public Courency Courency { get => _courency; set => _courency = value; }

        public virtual decimal Price
        {
            get => _price; 
            set
            {
                if(value < 0)
                    throw new ArgumentOutOfRangeException("Price can not be lower than 0");

                _price = value; 
            }
        }
        
        /// <summary>
        /// Weight in kilograms
        /// </summary>
        public float Weight
        {
            get => _weight;
            set
            {
                if (value < 0) // or just unsigned type
                    throw new ArgumentOutOfRangeException("Weight can not be lower than 0");

                _weight = value;
            }
        }

        public float WeightGrams
        {
            get => Weight * 1000F;
            set => Weight = value / 1000F;
        }

        public ProductModel(string name, decimal priceInUAH = 0, float weightInKilograms = 0, Courency courency = default)
        {
            _guid = Guid.NewGuid();
            Name = name;
            Price = priceInUAH;
            Weight = weightInKilograms;
            Courency = courency;
        }

        public Guid RegenerateGUID()
        {
            _guid = Guid.NewGuid();
            return _guid;
        }

        public virtual decimal GetChangedPrice(int percentages)
        {
            if (percentages < -100)
                throw new ArgumentOutOfRangeException("Percentages can not be lower than -100");

            return Price + percentages * Price / 100M;
        }

        public virtual void ChangePrice(int percentages)
        {
            Price = GetChangedPrice(percentages);
        }

        public void ChangePriceByOnlyPercentages(int percentages)
        {
            if (percentages < -100)
                throw new ArgumentOutOfRangeException("Percentages can not be lower than -100");

            Price += percentages * Price / 100M;
        }

        public override string ToString()
        {
            return $"--- [{Name} ({this.GetType().Name})] Weight {Weight} c.u.; Price {Price} {Courency};\n ({Guid})";
        }

        public override int GetHashCode() // Equals was overriden in previous homeworks
        {// І чому мені не подобається цей хард код?
            int hash = 17;
            hash = hash * 23 + Weight.GetHashCode();
            hash = hash * 23 + Price.GetHashCode();
            hash = hash * 23 + Name.GetHashCode();
            return hash;
        }

        public override bool Equals(object? obj) // Equals was overriden in previous homeworks
        {// приводити до типу можна тільки, коли об'єкт є цього типу. Операції аs має передувати операція is
            var product = obj as ProductModel;

            if(product == null) 
                return false;

            return product != null &&
                   this.Name == product.Name &&
                   this.Price == product.Price &&
                   this._weight == product._weight;
        }

        /// <returns>Shallow copy of the Product</returns>
        public object Clone()
        {
            return MemberwiseClone(); // We do not need deep copy for now???
        }

        public int CompareTo(object? obj)
        {
            ProductModel? product = obj as ProductModel;
            if( product == null)
                return -1;

            return ((IComparable)_guid).CompareTo(product.Guid);
        }

        public class SortByNameAscendingComparer : IComparer<ProductModel>
        {
            public int Compare(ProductModel? x, ProductModel? y)
            {
                if ((x is null) || (y is null))
                {
                    return 0;
                }

                string prod1Name = x?.Name ?? "";
                string prod2Name = y?.Name ?? "";

                return prod1Name.CompareTo(prod2Name);
            }
        }

        public static IComparer<ProductModel> SortByNameAscending() =>
            new SortByNameAscendingComparer();

        public class SortByNameDescendingComparer : IComparer<ProductModel>
        {
            public int Compare(ProductModel? x, ProductModel? y)
            {
                if ((x is null) || (y is null))
                {
                    return 0;
                }

                string prod1Name = x?.Name ?? "";
                string prod2Name = y?.Name ?? "";

                return prod2Name.CompareTo(prod1Name);
            }
        }

        public static IComparer<ProductModel> SortByNameDescending() =>
                new SortByNameDescendingComparer();

    }
}
