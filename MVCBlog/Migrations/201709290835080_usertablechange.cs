namespace MVCBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertablechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserModels", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserModels", "Password", c => c.String(nullable: false));
        }
    }
}
