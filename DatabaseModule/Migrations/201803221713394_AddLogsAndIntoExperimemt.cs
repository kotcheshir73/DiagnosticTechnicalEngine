namespace DatabaseModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogsAndIntoExperimemt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateLog = c.DateTime(nullable: false),
                        MessageLogType = c.String(),
                        MessageLogTitle = c.String(),
                        MessageLog = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ExperimentFileResults", "ForecastsByPoint", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExperimentFileResults", "ForecastsByPoint");
            DropTable("dbo.LogDatas");
        }
    }
}
