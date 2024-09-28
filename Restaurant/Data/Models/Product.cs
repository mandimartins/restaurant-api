namespace Restaurant.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        // Foreign key to the Category table
        public int IdCategory { get; set; }

        // Navigation property to the Category
        public Category Category { get; set; }
    }
}
