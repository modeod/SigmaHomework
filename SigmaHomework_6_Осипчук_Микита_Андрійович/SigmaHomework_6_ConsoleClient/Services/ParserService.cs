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
    public class ParserService : IParserService
    {
        public QuarterModel ParseTxt(string[] documentByLines)
        {
            string[] quarterInfoData = documentByLines[0].Split('|', StringSplitOptions.RemoveEmptyEntries);
            QuartersEnum quarter = (QuartersEnum)uint.Parse(quarterInfoData[0]);
            uint addressesNum = uint.Parse(quarterInfoData[1]);

            List<QuarterItemModel> items = new();
            if(documentByLines.Length > 1)
            {
                for (int i = 1; i < documentByLines.Length; i++)
                {
                    string[] itemInfoData = documentByLines[i].Split('|', StringSplitOptions.RemoveEmptyEntries);

                    PersonModel person = new(null, itemInfoData[1], null);

                    string[] adressData = itemInfoData[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    AddressModel address = new(
                        uint.Parse(adressData[3]), adressData[2], adressData[1],
                        adressData[0], null, null, person);

                    int inputValue = int.Parse(itemInfoData[2]);
                    int outputValue = int.Parse(itemInfoData[3]);

                    string[] dates = itemInfoData[4].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    DateTime date1 = DateTime.Parse(dates[0]);
                    DateTime date2 = DateTime.Parse(dates[1]);
                    DateTime date3 = DateTime.Parse(dates[2]);

                    QuarterItemModel item = new(address, inputValue, outputValue, date1, date2, date3);
                    items.Add(item);
                }
            }

            QuarterModel model = new(quarter, addressesNum, items);
            return model;
        }

        public QuarterModel ParseJSON(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
