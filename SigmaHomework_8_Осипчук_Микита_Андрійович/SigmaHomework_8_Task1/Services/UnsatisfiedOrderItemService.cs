using SigmaHomework_8_Task1.Models;
using SigmaHomework_8_Task1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_8_Task1.Services
{
    internal class UnsatisfiedOrderItemService
    {
        private readonly ISubstitutionsService _substitutionsService;
        private readonly IFileHandler _resultFileHandler;
        private readonly IStorageService _storageService;

        private SubstitutionsModel _substitutionsModel;

        public UnsatisfiedOrderItemService(ISubstitutionsService substitutionsService, IFileHandler resultFileHandler, IStorageService storageService)
        {
            _substitutionsService = substitutionsService;
            _resultFileHandler = resultFileHandler;
            _substitutionsModel = _substitutionsService.GetSubstitutions();
            _storageService = storageService;
        }

        public void OnOrderUnsatisfied(UnsatisfiedOrderItemModel unsatisfiedOrderItem)
        {
            StringBuilder sb = new();
            sb.AppendLine($"[!] Неможливо реалізувати з заказу компанії {unsatisfiedOrderItem.Company} предмет '{unsatisfiedOrderItem.ProductName}' ");
            sb.AppendLine($"Заказано {unsatisfiedOrderItem.Amount} шт. Не вистачає {unsatisfiedOrderItem.UnsatisfiedAmount}");
            sb.AppendLine($"Можливо замінити на:");

            var localStorage = _storageService.GetCashedStorage();

            if (_substitutionsModel.SubstitutionsDictionary
                    .TryGetValue(unsatisfiedOrderItem.ProductName,
                        out string[]? substitutions) && 
                substitutions != null && substitutions.Length > 0)
            {
                uint toSatisfy = unsatisfiedOrderItem.UnsatisfiedAmount;

                for (int i = 0; i < substitutions.Length; i++)
                {
                    if (localStorage.StorageItems
                            .TryGetValue(substitutions[i],
                                out uint amountAtStorage)
                       )
                    {
                        if(amountAtStorage > toSatisfy)
                        {
                            sb.AppendLine($" - {substitutions[i]}: {unsatisfiedOrderItem.UnsatisfiedAmount} шт.");
                        }
                    }
                }
            }
            else
            {
                sb.AppendLine("Замін для цього продукту немає");
            }

            _resultFileHandler.WriteOverride(sb.ToString());
        }

        public void UpdateSubstitutions()
        {
            _substitutionsModel = _substitutionsService.GetSubstitutions();
        }
    }
}
