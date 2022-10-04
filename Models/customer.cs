using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        public string FName { get; set; }

        [Required(ErrorMessage = "*")]
        public string LName { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})$", ErrorMessage ="Not Vaild Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage ="*")]
        [Compare("Password" , ErrorMessage ="Not Matched .")]
        public string Confirm_Password { get; set; }


        [Required(ErrorMessage = "*")]
        public string Address  { get; set; }

        [Required(ErrorMessage = "*")]
        public string Img { get; set; }


        [Required(ErrorMessage = "*")]
        [RegularExpression("^01[0125][0-9]{8}$",ErrorMessage ="Not Vaild Number")]
        public string Phone { get; set; }

        public ICollection<Order> orders { get; set; }
        public ICollection<Cart> carts { get; set; }
        public ICollection<admin> admins { get; set; }



    }
}
