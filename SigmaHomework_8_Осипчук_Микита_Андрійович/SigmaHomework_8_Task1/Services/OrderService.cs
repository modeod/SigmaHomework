using SigmaHomework_8_Task1.Services.Interfaces;
using SigmaHomework_8_Task1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_8_Task1.Services
{
    public delegate void OrderСannotBeSatisfiedHandler(UnsatisfiedOrderItemModel unsatisfiedOrder);

    public class OrderService
    {
        public event OrderСannotBeSatisfiedHandler? OrderСannotBeSatisfiedNotify;

        private readonly IParserOrder _parser;
        private readonly IFileHandler _fileHandler;
        private readonly IStorageService _storageService;

        public OrderService(
            IParserOrder parser,
            IFileHandler fileHandler,
            IStorageService storageService)
        {
            _parser = parser;
            _fileHandler = fileHandler;
            _storageService = storageService;
        }

        public OrderModel[] GetOrders()
        {
            string[] text = _fileHandler.Read();
            return _parser.ParseTxtOrders(text);
        }

        public void AnalyzeOrders()
        {
            var orders = this.GetOrders();
            var localStorage = _storageService.GetCashedStorage();

            for (int i = 0; i < orders.Length; i++)
            {
                var currOrder = orders[i];

                // Ключ - название товара в заказе, значение - количество товара В ЗАКАЗЕ КОМПАНИИ
                foreach (KeyValuePair<OrderItemModel, uint> orderItem in currOrder.Items)
                {
                    // Получаем количество продукта из заказа по имени СО СКЛАДА
                    if (localStorage.StorageItems.TryGetValue(orderItem.Key.Name, out uint productAmountInStorage))
                    {
                        // если тру - значит товар есть. Проверим количество
                        if (productAmountInStorage - (int)orderItem.Value >= 0)
                        {
                            // если тру - значит количество на складе удовлетворяет заказу. 
                            // Тут могла быть бизнес логика, если с заказом все хорошо
                            localStorage.StorageItems[orderItem.Key.Name] -= orderItem.Value;
                            continue;
                        }
                    }

                    // Если мы тут - значит предмет из заказа удовлетворить не удалось. 
                    // Создаем модель неудовлетворенного предмета и оповещаем всех подписчиков
                    UnsatisfiedOrderItemModel unsatisfiedOrderItem = new(
                                orderItem.Key.Name,
                                currOrder.Company,
                                (uint)orderItem.Value,
                                (uint)(orderItem.Value - productAmountInStorage));

                    OnOrderUnsatisfied(unsatisfiedOrderItem);
                }
            }
        }

        protected virtual void OnOrderUnsatisfied(UnsatisfiedOrderItemModel unsatisfiedOrderItem)
        {
            OrderСannotBeSatisfiedNotify?.Invoke(unsatisfiedOrderItem);
        }
    }
}
