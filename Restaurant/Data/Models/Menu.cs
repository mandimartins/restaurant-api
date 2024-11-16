namespace Restaurant.Data.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string ImageBase64 { get; set; }
        public string BadgeDescription { get; set; }
        public string BadgeColor { get; set; }
        public IList<MenuItem> MenuItem { get; set; }

    }
}
