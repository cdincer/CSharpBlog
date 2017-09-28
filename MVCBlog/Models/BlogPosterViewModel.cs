using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Models
{
    public class BlogPosterViewModel
    {
        public BlogPost Items { get; set; }
        public List<Category> Items2 { get; set; }
        public string CategoryCarrier { get; set; }
    }
}