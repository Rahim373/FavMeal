namespace FavMealService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "View", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "View");
        }
    }
}
