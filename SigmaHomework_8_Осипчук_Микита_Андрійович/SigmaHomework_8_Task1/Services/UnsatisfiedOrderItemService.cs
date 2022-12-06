using SigmaHomework_8_ConsoleClient.Services.Interfaces;
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
        private readonly IFileHandler _fileHandler;
        private readonly IStorageService _storageService;

        private SubstitutionsModel _substitutionsModel;

        public UnsatisfiedOrderItemService(ISubstitutionsService substitutionsService, IFileHandler fileHandler, IStorageService storageService)
        {
            _substitutionsService = substitutionsService;
            _fileHandler = fileHandler;
            _substitutionsModel = _substitutionsService.GetSubstitutions();
            _storageService = storageService;
        }

        public void OnOrderUnsatisfied(UnsatisfiedOrderItemModel unsatisfiedOrderItem)
        {
            StringBuilder sb = new();
            sb.AppendLine($"[!] Неможливо реалізувати з заказу компанії {unsatisfiedOrderItem.Company} предмет '{unsatisfiedOrderItem.ProductName}' ");
            sb.AppendLine($"Заказано {unsatisfiedOrderItem.Amount} шт. Не вистачає {unsatisfiedOrderItem.UnsatisfiedAmount}");
            sb.AppendLine($"Можливо замінити на:");

            if (_substitutionsModel.SubstitutionsDictionary
                    .TryGetValue(unsatisfiedOrderItem.ProductName,
                        out string[]? substitutions) && 
                substitutions != null && substitutions.Length > 0)
            { 
                var localStorage = _storageService.GetStorage();
                for (int i = 0; i < substitutions.Length; i++)
                {
                    if (localStorage.StorageItems
                            .TryGetValue(substitutions[i],
                                out int amountAtStorage) &&
                        amountAtStorage > unsatisfiedOrderItem.UnsatisfiedAmount)
                    {
                        sb.AppendLine($" - {substitutions[i]}: {unsatisfiedOrderItem.UnsatisfiedAmount} шт.");
                    }
                }
            }
            else
            {
                sb.AppendLine("Замін для цього продукту немає");
            }

            _fileHandler.Write(sb.ToString());
        }

        public void UpdateSubstitutions()
        {
            _substitutionsModel = _substitutionsService.GetSubstitutions();
        }
    }
}
