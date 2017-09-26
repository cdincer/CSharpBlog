using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Models
{
    public class PageViewModel
    {

        public BlogPost Items { get; set; }
        public Category Items2 { get; set; }
        public IEnumerable<CommentPost> Items3 { get; set; }
    }
}