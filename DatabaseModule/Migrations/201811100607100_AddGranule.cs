namespace DatabaseModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGranule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Granules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GranulePosition = c.Int(nullable: false),
                        LingvistUX = c.Int(nullable: false),
                        LingvistFT = c.Int(nullable: false),
                        FuzzyLabelId = c.Int(nullable: false),
                        FuzzyTrendId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DiagnosticTestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiagnosticTests", t => t.DiagnosticTestId, cascadeDelete: true)
                .ForeignKey("dbo.FuzzyLabels", t => t.FuzzyLabelId, cascadeDelete: false)
                .ForeignKey("dbo.FuzzyTrends", t => t.FuzzyTrendId, cascadeDelete: false)
                .Index(t => t.FuzzyLabelId)
                .Index(t => t.FuzzyTrendId)
                .Index(t => t.DiagnosticTestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Granules", "FuzzyTrendId", "dbo.FuzzyTrends");
            DropForeignKey("dbo.Granules", "FuzzyLabelId", "dbo.FuzzyLabels");
            DropForeignKey("dbo.Granules", "DiagnosticTestId", "dbo.DiagnosticTests");
            DropIndex("dbo.Granules", new[] { "DiagnosticTestId" });
            DropIndex("dbo.Granules", new[] { "FuzzyTrendId" });
            DropIndex("dbo.Granules", new[] { "FuzzyLabelId" });
            DropTable("dbo.Granules");
        }
    }
}
