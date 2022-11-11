using SigmaHomework_6_ConsoleClient.Models;
using SigmaHomework_6_ConsoleClient.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_6_ConsoleClient.Services
{
    public class QuarterFileHandlerService
    {
        private readonly IFileHandler _fileHandler;
        private readonly IParserService _parser;

        public QuarterFileHandlerService(IFileHandler fileHandler, IParserService parser)
        {
            _fileHandler = fileHandler;
            _parser = parser;
        }

        public QuarterModel GetQuarterFromFile()
        {
            string[] lines = _fileHandler.Read();
            return _parser.ParseTxt(lines);
        }

        public void WriteTextToReport(string message)
        {
            _fileHandler.Write(message);
        }

        public void WriteReadableQuarterToFile(QuarterModel quarter)
        {
            StringBuilder sb = new StringBuilder();

            int quarterNumX3 = (int)quarter.Quarter * 3;

            var firstMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(quarterNumX3 - 2).ToUpper();
            var secondMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(quarterNumX3 - 1).ToUpper();
            var thirdMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(quarterNumX3).ToUpper();


            var headerTable = GetTableHeader(firstMonthName, secondMonthName, thirdMonthName);

            sb.AppendLine(headerTable);
            sb.AppendLine(new string('-', 145));

            foreach (QuarterItemModel item in quarter.ElectricityMeters)
            {
                sb.AppendLine(QuarterItemToFormatString(item));
            }

            sb.AppendLine($"\nFlats Number = {quarter.ElectricityMeters.Count()}; Year {quarter.Year}");

            _fileHandler.WriteOverride(sb.ToString());
        }

        public void WriteReadableQuarterItemInformationToFile(QuarterItemModel item)
        {
            var headerTable = GetTableHeader("1st month", "2nd month", "3rd month");
            var result = QuarterItemToFormatString(item);
            _fileHandler.Write(headerTable + "\n" + result);
        }

        private string GetTableHeader(string firstMonthName, string secondMonthName, string thirdMonthName)
        {
            //TODO: Make formatting colums flexible
            return string.Format("|{0,-6}|{1,-20}|{2,-20}|{3,-20}|{4,-21}|{5,-21}|{6,-21}|",
                            "Room number", "Owner", "Input El. value", "Output El. value",
                            "Date for " + firstMonthName, "Date for " + secondMonthName, "Date for " + thirdMonthName);
        }

        private string QuarterItemToFormatString(QuarterItemModel item)
        {
            //TODO: Make formatting colums flexible
            return string.Format("|{0,-6}|{1,-20}|{2,-20:#}|{3,-20:#}|{4,-21:dd.MM.yy}|{5,-21:dd.MM.yy}|{6,-21:dd.MM.yy}|",
                item.Address.FlatNumber,
                item.Address.Owner.Surname,
                item.InputMeterValue,
                item.OutputMeterValue,
                item.FirstMonth,
                item.SecondMonth,
                item.ThirdMonth);
        }

        public void WriteDaysPassedFromLastEnergyMeterReadingToFile(Dictionary<AddressModel, int> energyMeters)
        {
            StringBuilder sb = new();
            sb.Append("Days passed from last energy meter reading");

            var header = string.Format("|{0,-9}|{1,-9}|", "Room", "Days");
            sb.AppendLine(header);
            sb.AppendLine(new String('-', 26));

            foreach (var item in energyMeters)
            {
                sb.AppendLine(string.Format("{0,-14}|{1,-9}", item.Key.FlatNumber, item.Value));
            }

            _fileHandler.Write(sb.ToString());
        }
    }
}
