namespace MVCBlog.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCBlog.Models.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVCBlog.Models.BlogContext context)
        {

            //Seeding a table with multiple DBsets 
            //context.CategoryTable.AddOrUpdate(x=>x.CategoryName,new Category { CategoryName = "EF Add or Update Command Test"});
            //context.SaveChanges();

            //context.BlogTable.AddOrUpdate(x => x.PostContent, new BlogPost { PostTitle = "EF add or update title"
            //, PostContent = "EF add or update title content", PostDate = DateTime.Parse("2017 - 09 - 01 12:35:00.000"),
            //    Category = context.CategoryTable.FirstOrDefault(x=>x.CategoryName == "EF Add or Update Command Test")
            //});

          

            IList<Category> CategoryList = new List<Category>();



            CategoryList.Add(new Category
            {
                CategoryName = " Skiing"
            });

            CategoryList.Add(new Category
            {
                CategoryName = " Boxing"
            });

            CategoryList.Add(new Category
            {
                CategoryName = " Racing"
            });
            CategoryList.Add(new Category
            {
                CategoryName = " Tennis"
            });

            CategoryList.Add(new Category
            {
                CategoryName = " Football"
            });

            foreach (Category categoryentry in CategoryList)
                context.CategoryTable.Add(categoryentry);
            base.Seed(context);

            IList<BlogPost> BlogPosts = new List<BlogPost>();

            BlogPosts.Add(new BlogPost()
            {
                PostTitle = "Post1-Updated",
                PostContent = "Post1 Content Updated by UI",
                PostDate = DateTime.Parse("2017 - 09 - 01 12:35:00.000"
               )

            });
            BlogPosts.Add(new BlogPost()
            {
                PostTitle = "Post2",
                PostContent = "Post2 Content",
                PostDate = DateTime.Parse("2017 - 09 - 02 00:00:00.000")
            });
            BlogPosts.Add(new BlogPost()
            {
                PostTitle = "Post3",
                PostContent = "Post3 Content",
                PostDate = DateTime.Parse("2017-09-03 00:00:00.000")
            });
            BlogPosts.Add(new BlogPost()
            {
                PostTitle = "Post4",
                PostContent = "Post4 content",
                PostDate = DateTime.Parse("2017 - 09 - 04 00:00:00.000")
            });
            BlogPosts.Add(new BlogPost()
            {
                PostTitle = "Post5",
                PostContent = "Post5 Content",
                PostDate = DateTime.Parse("2017-09-05 00:00:00.000"),
            });
            BlogPosts.Add(new BlogPost()
            {
                PostTitle = "Post6",
                PostContent = "Post6 Content",
                PostDate = DateTime.Parse("2017-10-05 00:00:00.000"),
            });
            BlogPosts.Add(new BlogPost()
            {
                PostTitle = "Post7",
                PostContent = "Post7 Content",
                PostDate = DateTime.Parse("2017 - 10 - 01 12:35:00.000")

            });
            BlogPosts.Add(new BlogPost()
            {
                PostTitle = "Post8",
                PostContent = "Post8 Content",
                PostDate = DateTime.Parse("2017 - 10 - 02 00:00:00.000")
            });
            BlogPosts.Add(new BlogPost()
            {
                PostTitle = "Post9",
                PostContent = "Post9 Content",
                PostDate = DateTime.Parse("2017-10-03 00:00:00.000")
            });
            BlogPosts.Add(new BlogPost()
            {
                PostTitle = "Post10",
                PostContent = "Post10 content",
                PostDate = DateTime.Parse("2017 - 10 - 04 00:00:00.000")
            });
            BlogPosts.Add(new BlogPost()
            {
                PostTitle = "Post11",
                PostContent = "Post11 Content",
                PostDate = DateTime.Parse("2017-10-05 00:00:00.000"),
            });
            BlogPosts.Add(new BlogPost()
            {
                PostTitle = "Post12",
                PostContent = "Post5 Content",
                PostDate = DateTime.Parse("2017-10-05 00:00:00.000"),
            });


            //foreach (BlogPost posting in BlogPosts)
            //    context.BlogTable.Add(posting);
            //base.Seed(context);


        }








        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. E.g.
        //
        //    context.People.AddOrUpdate(
        //      p => p.FullName,
        //      new Person { FullName = "Andrew Peters" },
        //      new Person { FullName = "Brice Lambson" },
        //      new Person { FullName = "Rowan Miller" }
        //    );
        //




    }
    }

