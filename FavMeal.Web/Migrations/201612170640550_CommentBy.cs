namespace FavMeal.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentBy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ReviewBy", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "ReviewBy");
            AddForeignKey("dbo.Comments", "ReviewBy", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ReviewBy", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "ReviewBy" });
            DropColumn("dbo.Comments", "ReviewBy");
        }
    }
}
