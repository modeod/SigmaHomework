using SigmaHomework_3_Task1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_3_Task1.ProductsModels
{
    public class DairyProductModel : ProductModel
    {
        private int _expirationDateInDays;
        private DateTime _manufacturingDate;

        public DateTime ManufacturingDate
        {
            get => _manufacturingDate;
            set
            {
                if (value > DateTime.Now.AddHours(1)) // To make it more resistant to interruptions 
                    throw new ArgumentOutOfRangeException("ManufacturingDate can not be greater than current time");

                _manufacturingDate = value;
            }
        }

        public int ExpirationDateInDays
        {
            get => _expirationDateInDays;
            set
            {
                if (value < 0) // or just unsigned type
                    throw new ArgumentOutOfRangeException("ExpirationDateInDays can not be lower than 0");

                _expirationDateInDays = value;
            }
        }

        public DairyProductModel(
            string name,
            int expirationDateInDays,
            DateTime manufacturingDate,
            decimal price = 0,
            float weight = 0
            ) : base(name, price, weight)
        {
            ExpirationDateInDays = expirationDateInDays;
            ManufacturingDate = manufacturingDate;
        }

        public override decimal GetChangedPrice(int percentages)
        {
            if (percentages < -100)
                throw new ArgumentOutOfRangeException("Percentages can not be lower than -100");

            decimal priceByExpirationDay = ManufacturingDate.AddDays(ExpirationDateInDays) > DateTime.Now ? (Price * 0.8M) : Price;

            return priceByExpirationDay + percentages * priceByExpirationDay / 100M; ;
        }

        //public override void ChangePrice(int percentages)
        //{
        //    Price = GetChangedPrice(percentages);
        //}

        public override int GetHashCode()
        {
            int hash = base.GetHashCode();
            hash = hash * 23 + ExpirationDateInDays.GetHashCode();
            hash = hash * 23 + ManufacturingDate.GetHashCode();
            return hash;
        }

        public override bool Equals(object? obj)
        {
            var dairy = obj as DairyProductModel;
            if (dairy == null)
                return false;

            return base.Equals(dairy) &&
                dairy.ExpirationDateInDays == this.ExpirationDateInDays &&
                dairy.ManufacturingDate == this.ManufacturingDate;
        }

        public override string ToString()
        {
            return base.ToString() + $"\n Manufacturing date: {ManufacturingDate};" +
                $" Storage time: {ExpirationDateInDays}, " +
                $"Days left: {(ManufacturingDate.AddDays(ExpirationDateInDays) - DateTime.Now).TotalDays} ";
        }
    }
}
