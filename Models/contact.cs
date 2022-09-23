using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class contact
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        public string  Name { get; set; }
        [Required(ErrorMessage = "*")]

        public string Message { get; set; }
        
        [Required(ErrorMessage = "*")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})$", ErrorMessage = "Not Vaild Email")]
        public string Email { get; set; }

        public string choose { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int customer_id { get; set; }

        [ForeignKey("customer_id")]
        public customer customer { get; set; }

    }
}
