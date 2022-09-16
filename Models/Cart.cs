using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Img { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }


        public int customer_id { get; set; }

        [ForeignKey("customer_id")]
        public customer customer { get; set; }

    }
}
