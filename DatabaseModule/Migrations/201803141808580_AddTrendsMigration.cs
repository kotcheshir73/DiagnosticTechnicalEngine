namespace DatabaseModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrendsMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PointTrends", "Trends", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PointTrends", "Trends");
        }
    }
}
