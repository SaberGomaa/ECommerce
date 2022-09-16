﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.ModelView
{
    public class Login
    {

        [Required(ErrorMessage = "*")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})$", ErrorMessage = "Not Vaild Email")]
        public string  Email { get; set; }
        
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }
    }
}
