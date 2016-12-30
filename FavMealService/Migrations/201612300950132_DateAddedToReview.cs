namespace FavMealService.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class DateAddedToReview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "UploadTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "UploadTime");
        }
    }
}
