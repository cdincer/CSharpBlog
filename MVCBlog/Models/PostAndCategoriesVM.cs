using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Models
{
    public class PostAndCategoriesVM
    {
        public Category CategoryList { get; set; }
        public BlogPost BlogPostList { get; set; }

    }
}