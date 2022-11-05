using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_4_Task1.Enums;

namespace SigmaHomework_4_Task1.ProductsModels
{
    public class MeatModel : ProductModel
    {
        public MeatType MeatType { get; set; }
        public MeatCategory MeatCategory { get; set; }

        public MeatModel(
            string name,
            decimal price = 0,
            float weight = 0,
            MeatType meatType = MeatType.Lamb,
            MeatCategory meatCategory = MeatCategory.Hanging,
            Courency courency = default) : base(name, price, weight, courency)
        {
            MeatType = meatType;
            MeatCategory = meatCategory;
        }

        public override decimal GetChangedPrice(int percentages)
        {
            if (percentages < -100)
                throw new ArgumentOutOfRangeException("Percentages can not be lower than -100");

            decimal priceByCategory = Price * (decimal)MeatType / 100M;
            return priceByCategory + percentages * priceByCategory / 100M;
        }

        public override int GetHashCode() // Equals was overriden in previous homeworks
        {
            int hash = base.GetHashCode();
            hash = hash * 23 + MeatType.GetHashCode();
            hash = hash * 23 + MeatCategory.GetHashCode();
            return hash;
        }

        public override bool Equals(object? obj) // Equals was overriden in previous homeworks
        {
            var meat = obj as MeatModel;
            if (meat == null)
                return false;

            return base.Equals(meat) &&
                meat.MeatType == MeatType &&
                meat.MeatCategory == MeatCategory;
        }

        public override string ToString()
        {
            return base.ToString() + $"\n Meat type: {MeatType}, Meat category: {MeatCategory}";
        }
    }
}
