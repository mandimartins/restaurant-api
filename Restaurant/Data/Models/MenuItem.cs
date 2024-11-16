namespace Restaurant.Data.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int IdMenu { get; set; }
        public int IdProduct { get; set; }

        public Product Product { get; set; }

        public Menu Menu { get; set; }
    }
}
