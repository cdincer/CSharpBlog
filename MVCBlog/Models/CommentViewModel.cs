using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Models
{
    public class CommentViewModel
    {
        public BlogPost Items { get; set; }
        public CommentPost Items2 { get; set; }
        public UserModel Items3 { get; set; }
    }
}