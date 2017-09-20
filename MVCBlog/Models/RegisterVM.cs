using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Models
{
    public class RegisterVM
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,12})$")]
        public string Password { get; set; }

        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}