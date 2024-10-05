
namespace Restaurant.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property for the related products
        public ICollection<Product> Products { get; set; }
    }
}
