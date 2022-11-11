using SigmaHomework_6_ConsoleClient.Models;
using SigmaHomework_6_ConsoleClient.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_6_ConsoleClient.Services
{
    public class QuarterService
    {
        private QuarterModel _quarter;

        public QuarterService(QuarterModel quarter)
        {
            _quarter = quarter;
        }

        // IDK what to return^ address model or just QuarterItemModel
        public IDictionary<AddressModel, decimal> GetBillForEveryAddress()
        {
            Dictionary<AddressModel, decimal> result = new Dictionary<AddressModel, decimal>();

            foreach(QuarterItemModel meter in _quarter.ElectricityMeters)
            {
                decimal sum = ( meter.OutputMeterValue - meter.InputMeterValue ) * Settings.KWPrice;
                result.Add(meter.Address, sum);
            }

            return result;
        }

        public IEnumerable<AddressModel> FindAddressesNotUsedEvecticity() =>
            _quarter.ElectricityMeters.Where(item => item.OutputMeterValue - item.InputMeterValue == 0).Select(item => item.Address);

        public IDictionary<AddressModel, int> GetDaysPassedFromLastEnergyMeterReading() =>
            _quarter.ElectricityMeters.ToDictionary(
                item => item.Address,
                item => (int)(( DateTime.Now - item.ThirdMonth).TotalDays)
            );

        public QuarterItemModel? FindAddressWithTheHighestDebt() =>
            (QuarterItemModel?)_quarter.ElectricityMeters.MaxBy(item => item.OutputMeterValue - item.InputMeterValue)?.Clone();

    }
}
