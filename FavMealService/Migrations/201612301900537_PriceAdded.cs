namespace FavMealService.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class PriceAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "Price");
        }
    }
}
