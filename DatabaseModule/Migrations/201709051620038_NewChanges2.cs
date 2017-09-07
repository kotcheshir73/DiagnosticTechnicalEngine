namespace DatabaseModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnomalyInfoes", "DiagnosticTestId", "dbo.DiagnosticTests");
            DropForeignKey("dbo.StatisticsByEntropies", "DiagnosticTestId", "dbo.DiagnosticTests");
            DropForeignKey("dbo.StatisticsByFuzzies", "DiagnosticTestId", "dbo.DiagnosticTests");
            DropIndex("dbo.AnomalyInfoes", new[] { "DiagnosticTestId" });
            DropIndex("dbo.StatisticsByEntropies", new[] { "DiagnosticTestId" });
            DropIndex("dbo.StatisticsByFuzzies", new[] { "DiagnosticTestId" });
            AddColumn("dbo.AnomalyInfoes", "SeriesDiscriptionId", c => c.Int(nullable: false));
            AddColumn("dbo.SeriesDescriptions", "NeedForecast", c => c.Boolean(nullable: false));
            AddColumn("dbo.StatisticsByEntropies", "SeriesDiscriptionId", c => c.Int(nullable: false));
            AddColumn("dbo.StatisticsByFuzzies", "SeriesDiscriptionId", c => c.Int(nullable: false));
            CreateIndex("dbo.AnomalyInfoes", "SeriesDiscriptionId");
            CreateIndex("dbo.StatisticsByEntropies", "SeriesDiscriptionId");
            CreateIndex("dbo.StatisticsByFuzzies", "SeriesDiscriptionId");
            AddForeignKey("dbo.AnomalyInfoes", "SeriesDiscriptionId", "dbo.SeriesDescriptions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StatisticsByEntropies", "SeriesDiscriptionId", "dbo.SeriesDescriptions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StatisticsByFuzzies", "SeriesDiscriptionId", "dbo.SeriesDescriptions", "Id", cascadeDelete: true);
            DropColumn("dbo.AnomalyInfoes", "DiagnosticTestId");
            DropColumn("dbo.DiagnosticTests", "NeedForecast");
            DropColumn("dbo.StatisticsByEntropies", "DiagnosticTestId");
            DropColumn("dbo.StatisticsByFuzzies", "DiagnosticTestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StatisticsByFuzzies", "DiagnosticTestId", c => c.Int(nullable: false));
            AddColumn("dbo.StatisticsByEntropies", "DiagnosticTestId", c => c.Int(nullable: false));
            AddColumn("dbo.DiagnosticTests", "NeedForecast", c => c.Boolean(nullable: false));
            AddColumn("dbo.AnomalyInfoes", "DiagnosticTestId", c => c.Int(nullable: false));
            DropForeignKey("dbo.StatisticsByFuzzies", "SeriesDiscriptionId", "dbo.SeriesDescriptions");
            DropForeignKey("dbo.StatisticsByEntropies", "SeriesDiscriptionId", "dbo.SeriesDescriptions");
            DropForeignKey("dbo.AnomalyInfoes", "SeriesDiscriptionId", "dbo.SeriesDescriptions");
            DropIndex("dbo.StatisticsByFuzzies", new[] { "SeriesDiscriptionId" });
            DropIndex("dbo.StatisticsByEntropies", new[] { "SeriesDiscriptionId" });
            DropIndex("dbo.AnomalyInfoes", new[] { "SeriesDiscriptionId" });
            DropColumn("dbo.StatisticsByFuzzies", "SeriesDiscriptionId");
            DropColumn("dbo.StatisticsByEntropies", "SeriesDiscriptionId");
            DropColumn("dbo.SeriesDescriptions", "NeedForecast");
            DropColumn("dbo.AnomalyInfoes", "SeriesDiscriptionId");
            CreateIndex("dbo.StatisticsByFuzzies", "DiagnosticTestId");
            CreateIndex("dbo.StatisticsByEntropies", "DiagnosticTestId");
            CreateIndex("dbo.AnomalyInfoes", "DiagnosticTestId");
            AddForeignKey("dbo.StatisticsByFuzzies", "DiagnosticTestId", "dbo.DiagnosticTests", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StatisticsByEntropies", "DiagnosticTestId", "dbo.DiagnosticTests", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AnomalyInfoes", "DiagnosticTestId", "dbo.DiagnosticTests", "Id", cascadeDelete: true);
        }
    }
}
