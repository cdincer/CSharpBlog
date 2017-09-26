using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Models
{
    public class CommentPost
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}