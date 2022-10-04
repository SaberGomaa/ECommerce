using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]

        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        public double Price { get; set; }
        [Required(ErrorMessage = "*")]
        public string  Img { get; set; }

        public string Color { get; set; } // drop downlist Options
        public string Size { get; set; } // drop downlist Options
       
        [Required(ErrorMessage ="*")]
        public int Quantity { get; set; }
        public string? Details { get; set; }

        public string Category { get; set; }

        public ICollection<Order> orders { get; set; }
        public ICollection<Cart> carts { get; set; }
        public ICollection<admin> admins { get; set; }


    }
}
