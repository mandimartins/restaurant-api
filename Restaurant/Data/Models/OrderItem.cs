namespace Restaurant.Data.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } = 0;
        public decimal PriceTotal { get; set;} = 0;

        public int IdOrder { get; set; }
        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
