﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Models
{
    public class LoginVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}