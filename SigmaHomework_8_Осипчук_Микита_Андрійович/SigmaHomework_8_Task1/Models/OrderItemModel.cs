namespace SigmaHomework_8_Task1.Models
{
    public class OrderItemModel : IEquatable<OrderItemModel?>
    {
        public string Name { get; set; }

        public OrderItemModel(string name)
        {
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as OrderItemModel);
        }

        public bool Equals(OrderItemModel? other)
        {
            return other is not null &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}