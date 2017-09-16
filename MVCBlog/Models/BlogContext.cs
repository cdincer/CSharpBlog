using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCBlog.Models
{
    public class BlogContext:DbContext
    {

        public DbSet<BlogPost> BlogTables { get; set; }
    }
}