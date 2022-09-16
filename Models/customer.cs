using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address  { get; set; }
        public string Img { get; set; }
        public string Phone { get; set; }

        public ICollection<orderTable> orders { get; set; }
        public ICollection<Cart> carts { get; set; }


    }
}
