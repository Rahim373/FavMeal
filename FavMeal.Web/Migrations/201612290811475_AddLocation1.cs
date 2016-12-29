namespace FavMeal.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocation1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Locations", new[] { "Restaurant_Id" });
            CreateTable(
                "dbo.LocationRestaurants",
                c => new
                    {
                        Location_Id = c.Int(nullable: false),
                        Restaurant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Location_Id, t.Restaurant_Id })
                .ForeignKey("dbo.Locations", t => t.Location_Id, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id, cascadeDelete: true)
                .Index(t => t.Location_Id)
                .Index(t => t.Restaurant_Id);
            
            DropColumn("dbo.Locations", "Restaurant_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Restaurant_Id", c => c.Int());
            DropForeignKey("dbo.LocationRestaurants", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.LocationRestaurants", "Location_Id", "dbo.Locations");
            DropIndex("dbo.LocationRestaurants", new[] { "Restaurant_Id" });
            DropIndex("dbo.LocationRestaurants", new[] { "Location_Id" });
            DropTable("dbo.LocationRestaurants");
            CreateIndex("dbo.Locations", "Restaurant_Id");
            AddForeignKey("dbo.Locations", "Restaurant_Id", "dbo.Restaurants", "Id");
        }
    }
}
