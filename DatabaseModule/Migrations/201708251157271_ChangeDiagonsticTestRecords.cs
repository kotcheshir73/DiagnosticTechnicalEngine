namespace DatabaseModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDiagonsticTestRecords : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiagnosticTestRecords", "AnomalyInfoId", c => c.Int(nullable: false));
            CreateIndex("dbo.DiagnosticTestRecords", "AnomalyInfoId");
            AddForeignKey("dbo.DiagnosticTestRecords", "AnomalyInfoId", "dbo.AnomalyInfoes", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiagnosticTestRecords", "AnomalyInfoId", "dbo.AnomalyInfoes");
            DropIndex("dbo.DiagnosticTestRecords", new[] { "AnomalyInfoId" });
            DropColumn("dbo.DiagnosticTestRecords", "AnomalyInfoId");
        }
    }
}
