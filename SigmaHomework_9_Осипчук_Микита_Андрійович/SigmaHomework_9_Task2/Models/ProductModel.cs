using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_9_Task2.Models
{
    public class ProductModel : IEquatable<ProductModel?>, IComparable<ProductModel>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ProductModel(string name = "Potato", decimal price = default)
        {
            Name = name;
            Price = price;
        }

        public ProductModel()
        {
            Name = "Potato";
            Price = default;
        }

        public int CompareTo(ProductModel? other) => other is null ? 1 : Price.CompareTo(other.Price);

        public class SortByPriceAscendingComparer : IComparer<ProductModel>
        {
            public int Compare(ProductModel? x, ProductModel? y)
            {
                if ((x is null) || (y is null))
                    return 0;

                return x.Price.CompareTo(y.Price);
            }
        }

        public static IComparer<ProductModel> SortByPriceAscending() =>
            new SortByPriceAscendingComparer();

        public bool Equals(ProductModel? other) =>
            other is not null &&
                   Name == other.Name &&
                   Price == other.Price;

        public override bool Equals(object? obj) =>
           Equals(obj as ProductModel);

        public override int GetHashCode() => 
            HashCode.Combine(Name, Price);

        public override string? ToString() =>
            $"[{Price}$] {Name}";
    }
}
