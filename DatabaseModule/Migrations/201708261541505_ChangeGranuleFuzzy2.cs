namespace DatabaseModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGranuleFuzzy2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.GranuleFuzzies", "FuzzyLabelId");
            CreateIndex("dbo.GranuleFuzzies", "FuzzyTrendId");
            AddForeignKey("dbo.GranuleFuzzies", "FuzzyLabelId", "dbo.FuzzyLabels", "Id", cascadeDelete: false);
            AddForeignKey("dbo.GranuleFuzzies", "FuzzyTrendId", "dbo.FuzzyTrends", "Id", cascadeDelete: false);
            DropColumn("dbo.GranuleFuzzies", "FuzzyLabel");
            DropColumn("dbo.GranuleFuzzies", "FuzzyTrend");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GranuleFuzzies", "FuzzyTrend", c => c.String());
            AddColumn("dbo.GranuleFuzzies", "FuzzyLabel", c => c.String());
            DropForeignKey("dbo.GranuleFuzzies", "FuzzyTrendId", "dbo.FuzzyTrends");
            DropForeignKey("dbo.GranuleFuzzies", "FuzzyLabelId", "dbo.FuzzyLabels");
            DropIndex("dbo.GranuleFuzzies", new[] { "FuzzyTrendId" });
            DropIndex("dbo.GranuleFuzzies", new[] { "FuzzyLabelId" });
        }
    }
}
