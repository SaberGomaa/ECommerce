using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class admin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Img { get; set; }
        public string Phone { get; set; }

        public int customer_id { get; set; }
        public int product_id { get; set; }

        [ForeignKey("product_id")]
        public Product Product { get; set; }

        [ForeignKey("customer_id")]
        public customer customer { get; set; }

    }
}
