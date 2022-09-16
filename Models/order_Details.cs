using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class order_Details
    {
        [Key]
        public int Id { get; set; }
        public double subTotal  { get; set; }

        public int  product_Quantity { get; set; }
        public double product_price { get; set; }

        public int order_id { get; set; }

        public int product_id { get; set; }

        [ForeignKey("order_id")]
        public orderTable orderTable { get; set; }


        [ForeignKey("product_id")]
        public Product product { get; set; }


    }
}
