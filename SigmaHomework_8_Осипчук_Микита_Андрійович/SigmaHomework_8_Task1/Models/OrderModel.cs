namespace SigmaHomework_8_Task1.Models
{
    public class OrderModel
    {
        public string Company { get; set; }

        public readonly Dictionary<OrderItemModel, int> Items { get; set; };

        public OrderModel(string company, Dictionary<OrderItemModel, int> items)
        {
            Company = company;
            this.Items = items;
        }

        public OrderModel()
        {
            Company = "";
            Items = new Dictionary<OrderItemModel, int>();
        }
    }
}