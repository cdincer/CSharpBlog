namespace MVCBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserId2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommentPosts", "UserModels_ID", "dbo.UserModels");
            DropIndex("dbo.CommentPosts", new[] { "UserModels_ID" });
            RenameColumn(table: "dbo.CommentPosts", name: "UserModels_ID", newName: "UserModelId");
            AlterColumn("dbo.CommentPosts", "UserModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.CommentPosts", "UserModelId");
            AddForeignKey("dbo.CommentPosts", "UserModelId", "dbo.UserModels", "ID", cascadeDelete: true);
            DropColumn("dbo.CommentPosts", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CommentPosts", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CommentPosts", "UserModelId", "dbo.UserModels");
            DropIndex("dbo.CommentPosts", new[] { "UserModelId" });
            AlterColumn("dbo.CommentPosts", "UserModelId", c => c.Int());
            RenameColumn(table: "dbo.CommentPosts", name: "UserModelId", newName: "UserModels_ID");
            CreateIndex("dbo.CommentPosts", "UserModels_ID");
            AddForeignKey("dbo.CommentPosts", "UserModels_ID", "dbo.UserModels", "ID");
        }
    }
}
