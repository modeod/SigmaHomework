using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_6_ConsoleClient.Models
{
    public class QuarterModel : ICloneable
    {
        private List<QuarterItemModel> _electricityMeters;

        public uint Adresses { get; private set; }

        public QuartersEnum Quarter { get; set; }

        public uint Year { get; set; }

        public IEnumerable<QuarterItemModel> ElectricityMeters
        {
            get => _electricityMeters;
            private set => _electricityMeters = value.ToList();
        }

        public QuarterModel(QuartersEnum quarter, uint adressesNumber, IEnumerable<QuarterItemModel> electricityMeters, uint year = 2022)
        {
            Year = year;
            Adresses = adressesNumber;
            Quarter = quarter;
            _electricityMeters = electricityMeters.ToList(); 
        }

        public QuarterItemModel this[int index]
        {
            get => _electricityMeters[index];
            set => _electricityMeters[index] = (QuarterItemModel)value.Clone();
        }

        public object Clone()
        {
            var quarter = this.MemberwiseClone() as QuarterModel;
            quarter._electricityMeters = this._electricityMeters.ToList();
            return quarter;
        }
    }
}
