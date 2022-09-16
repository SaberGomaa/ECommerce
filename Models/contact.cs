using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class contact
    {
        [Key]
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int customer_id { get; set; }

        [ForeignKey("customer_id")]
        public customer customer { get; set; }

    }
}
