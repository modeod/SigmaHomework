using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_6_ConsoleClient.Models
{
    public class QuarterItemModel : ICloneable
    {
        private AddressModel _address;

        public AddressModel Address
        {
            get => (AddressModel)_address.Clone();
            set => _address = (AddressModel)value.Clone();
        }

        public int InputMeterValue { get; set; }
        public int OutputMeterValue { get; set; }

        private DateTime _firstMonth;
        private DateTime _secondMonth;
        private DateTime _thirdMonth;

        public QuarterItemModel(
            AddressModel address,
            int inputMeterValue,
            int outputMeterValue,
            DateTime firstMonth,
            DateTime secondMonth,
            DateTime thirdMonth)
        {
            Address = address;
            InputMeterValue = inputMeterValue;
            OutputMeterValue = outputMeterValue;
            FirstMonth = firstMonth;
            SecondMonth = secondMonth;
            ThirdMonth = thirdMonth;
        }

        public DateTime FirstMonth
        {
            get => _firstMonth;
            set
            {
                //TODO: Quarter month validation
                _firstMonth = value;
            }
        }

        public DateTime SecondMonth { get => _secondMonth; set => _secondMonth = value; }

        public DateTime ThirdMonth { get => _thirdMonth; set => _thirdMonth = value; }

        public override bool Equals(object? obj)
        {
            return obj is QuarterItemModel model &&
                   EqualityComparer<AddressModel>.Default.Equals(_address, model._address) &&
                   InputMeterValue == model.InputMeterValue &&
                   OutputMeterValue == model.OutputMeterValue &&
                   _firstMonth.Equals(model._firstMonth) &&
                   _secondMonth.Equals(model._secondMonth) &&
                   _thirdMonth.Equals(model._thirdMonth);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_address, InputMeterValue, OutputMeterValue, _firstMonth, _secondMonth, _thirdMonth);
        }

        public object Clone()
        {
            QuarterItemModel item = MemberwiseClone() as QuarterItemModel;
            item._address = this.Address; // set => _address = (AddressModel)value.Clone();
            return item;
        }
    }
}
