using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Order
    {

        public int Id { get; set; }

        public int product_id { get; set; }

        public double subTotal { get; set; }
        public int Quantity { get; set; }

        public string Size { get; set; }
        public string Color { get; set; }

        public DateTime order_date { get; set; }
        public double order_total { get; set; }
        public int customer_id { get; set; }

        [ForeignKey("customer_id")]
        public customer Customer { get; set; }

        [ForeignKey("product_id")]
        public Product product { get; set; }

    }
}
