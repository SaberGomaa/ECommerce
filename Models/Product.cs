using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string  Img { get; set; }
        public string Color { get; set; } // drop downlist Options
        public string Size { get; set; } // drop downlist Options
        public int Quantity { get; set; }
        public string? Details { get; set; }

        public string Category { get; set; }

        public ICollection<order_Details> order_Details { get; set; }

    }
}
