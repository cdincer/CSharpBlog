namespace MVCBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogPostIdaddedtoCommentposttable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommentPosts", "BlogPost_ID", "dbo.BlogPosts");
            DropIndex("dbo.CommentPosts", new[] { "BlogPost_ID" });
            RenameColumn(table: "dbo.CommentPosts", name: "BlogPost_ID", newName: "BlogPostId");
            AlterColumn("dbo.CommentPosts", "BlogPostId", c => c.Int(nullable: false));
            CreateIndex("dbo.CommentPosts", "BlogPostId");
            AddForeignKey("dbo.CommentPosts", "BlogPostId", "dbo.BlogPosts", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentPosts", "BlogPostId", "dbo.BlogPosts");
            DropIndex("dbo.CommentPosts", new[] { "BlogPostId" });
            AlterColumn("dbo.CommentPosts", "BlogPostId", c => c.Int());
            RenameColumn(table: "dbo.CommentPosts", name: "BlogPostId", newName: "BlogPost_ID");
            CreateIndex("dbo.CommentPosts", "BlogPost_ID");
            AddForeignKey("dbo.CommentPosts", "BlogPost_ID", "dbo.BlogPosts", "ID");
        }
    }
}
