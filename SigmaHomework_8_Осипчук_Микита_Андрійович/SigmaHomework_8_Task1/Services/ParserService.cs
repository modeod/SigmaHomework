using SigmaHomework_8_Task1.Services.Interfaces;
using SigmaHomework_8_Task1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_8_Task1.Services
{
    public class ParserService : IParserOrder, IParserSubstitutions
    {
        public OrderModel[] ParseTxtOrders(string[] documentByLines)
        {
            Dictionary<string, OrderModel> orders = new Dictionary<string, OrderModel>();

            for (int i = 0; i < documentByLines.Length; i++)
            {
                string[] orderInfoData = documentByLines[i].Split(',', StringSplitOptions.RemoveEmptyEntries);
                string company = orderInfoData[0].Trim();
                string productName = orderInfoData[1].Trim();
                uint productNum = uint.Parse(orderInfoData[2].Trim());

                if( ! orders.TryGetValue(company, out OrderModel order))
                {
                    orders.Add(company, new OrderModel(company, new Dictionary<OrderItemModel, uint>()));
                }

                orders[company].Items.Add(new OrderItemModel(productName), productNum);
            }

            return orders.Select(kvp => kvp.Value).ToArray();
        }

        public SubstitutionsModel ParseTxtSubstitutions(string[] documentByLines)
        {
            SubstitutionsModel substitutions = new SubstitutionsModel(new Dictionary<string, string[]>());

            for (int i = 0; i < documentByLines.Length; i++)
            {
                string[] substitutionsInfoData = documentByLines[i].Split('-', StringSplitOptions.RemoveEmptyEntries);
                string[] productSubstitutions = substitutionsInfoData[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                substitutions.SubstitutionsDictionary.Add(
                    substitutionsInfoData[0].Trim(),
                    productSubstitutions
                        .Select(p => p.Trim()).ToArray());
            }

            return substitutions;
        }
    }
}
