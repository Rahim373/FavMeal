namespace FavMeal.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
            DropColumn("dbo.Restaurants", "Longitude");
            DropColumn("dbo.Restaurants", "Latitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Latitude", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Restaurants", "Longitude", c => c.String(nullable: false, maxLength: 15));
            DropForeignKey("dbo.Locations", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Locations", new[] { "Restaurant_Id" });
            DropTable("dbo.Locations");
        }
    }
}
