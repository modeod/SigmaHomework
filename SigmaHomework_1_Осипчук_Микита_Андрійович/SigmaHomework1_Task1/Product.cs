using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework1_Task1
{
    public class Product : ICloneable
    {
        private float _weight;
        private decimal _price;

        public string Name { get; set; }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0) // or just unsigned type
                    throw new ArgumentOutOfRangeException("Price can not be lower than 0");

                _price = value;
            }
        }

        public float Weight
        {
            get => _weight;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Weight can not be lower than 0");

                _weight = value;
            }
        }

        public Product(string name, decimal price = 0, float weight = 0)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"- [{this.Name}]: weight {Weight} c.u., price {Price} c.u.";
        }

        /// <returns>Shallow copy of the Product</returns>
        public object Clone()
        {
            return this.MemberwiseClone(); // We do not need deep copy for now???
        }
    }
}
