namespace MVCBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogPostCategoryIDadd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogPosts", "Category_Id", "dbo.Categories");
            DropIndex("dbo.BlogPosts", new[] { "Category_Id" });
            RenameColumn(table: "dbo.BlogPosts", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.BlogPosts", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.BlogPosts", "CategoryId");
            AddForeignKey("dbo.BlogPosts", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.BlogPosts", new[] { "CategoryId" });
            AlterColumn("dbo.BlogPosts", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.BlogPosts", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.BlogPosts", "Category_Id");
            AddForeignKey("dbo.BlogPosts", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
