using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class orderTable
    {
        [Key]
        public int Id { get; set; }
        public DateTime order_date { get; set; }
        public double order_total { get; set; }

        public int customer_id { get; set; }

        [ForeignKey("customer_id")]
        public customer Customer { get; set; }


        public ICollection<order_Details> order_Details { get; set; }
    }
}
