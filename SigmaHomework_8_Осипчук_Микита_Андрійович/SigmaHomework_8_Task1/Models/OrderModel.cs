namespace SigmaHomework_8_Task1.Models
{
    public class OrderModel
    {
        public string Company { get; set; }

        public Dictionary<OrderItemModel, uint> Items { get; }

        public OrderModel(string company, Dictionary<OrderItemModel, uint> items)
        {
            Company = company;
            this.Items = items;
        }

        public OrderModel()
        {
            Company = "";
            Items = new Dictionary<OrderItemModel, uint>();
        }
    }
}