namespace DatabaseModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExperimentFileResult : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExperimentFileResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        DateExperiment = c.DateTime(nullable: false),
                        Forecast = c.Double(nullable: false),
                        RealValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExperimentFileResults");
        }
    }
}
