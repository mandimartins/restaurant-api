namespace Restaurant.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public IList<OrderItem> OrderItem { get; set; }
    }
}
