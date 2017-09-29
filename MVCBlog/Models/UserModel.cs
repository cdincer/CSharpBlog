using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCBlog.Models
{
    public class UserModel
    {
        public int ID { get; set; }


        [EmailAddress]
        [Required]
        public string Email { get; set; }

     
        public string Password { get; set; }

        public string UserRole { get; set; }


    }
}