using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCBlog.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("name=DefaultConnection")
        { }
       

        public DbSet<BlogPost> BlogTable { get; set; }
        public DbSet<UserModel> UserTable { get; set; }
    }
}