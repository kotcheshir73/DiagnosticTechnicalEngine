namespace DatabaseModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnomalyInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeSituation = c.Int(nullable: false),
                        AnomalyName = c.String(),
                        AnomalySituation = c.Int(nullable: false),
                        SetSituations = c.String(),
                        TypeMemoryValue = c.Int(nullable: false),
                        SetValues = c.String(),
                        Description = c.String(),
                        CountMeet = c.Int(nullable: false),
                        NotAnomaly = c.Boolean(nullable: false),
                        NotDetected = c.Boolean(nullable: false),
                        SeriesDiscriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SeriesDescriptions", t => t.SeriesDiscriptionId, cascadeDelete: true)
                .Index(t => t.SeriesDiscriptionId);
            
            CreateTable(
                "dbo.SeriesDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeriesName = c.String(),
                        SeriesDiscription = c.String(),
                        NeedForecast = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiagnosticTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestNumber = c.String(),
                        DateTest = c.DateTime(nullable: false),
                        Count = c.Int(nullable: false),
                        FileName = c.String(),
                        SeriesDiscriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SeriesDescriptions", t => t.SeriesDiscriptionId, cascadeDelete: true)
                .Index(t => t.SeriesDiscriptionId);
            
            CreateTable(
                "dbo.DiagnosticTestRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnomalyInfoId = c.Int(nullable: false),
                        PointNumber = c.Int(),
                        Description = c.String(),
                        DiagnosticTestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnomalyInfoes", t => t.AnomalyInfoId, cascadeDelete: false)
                .ForeignKey("dbo.DiagnosticTests", t => t.DiagnosticTestId, cascadeDelete: true)
                .Index(t => t.AnomalyInfoId)
                .Index(t => t.DiagnosticTestId);
            
            CreateTable(
                "dbo.GranuleEntropies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GranulePosition = c.Int(nullable: false),
                        LingvistUX = c.Int(nullable: false),
                        LingvistFT = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DiagnosticTestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiagnosticTests", t => t.DiagnosticTestId, cascadeDelete: true)
                .Index(t => t.DiagnosticTestId);
            
            CreateTable(
                "dbo.GranuleFTs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GranulePosition = c.Int(nullable: false),
                        LingvistFT = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DiagnosticTestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiagnosticTests", t => t.DiagnosticTestId, cascadeDelete: true)
                .Index(t => t.DiagnosticTestId);
            
            CreateTable(
                "dbo.GranuleFuzzies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GranulePosition = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.FuzzyLabels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FuzzyLabelType = c.Int(nullable: false),
                        FuzzyLabelName = c.String(),
                        FuzzyLabelWeight = c.Int(nullable: false),
                        FuzzyLabelMinVal = c.Double(nullable: false),
                        FuzzyLabelCenter = c.Double(nullable: false),
                        FuzzyLabelMaxVal = c.Double(nullable: false),
                        SeriesDiscriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SeriesDescriptions", t => t.SeriesDiscriptionId, cascadeDelete: true)
                .Index(t => t.SeriesDiscriptionId);
            
            CreateTable(
                "dbo.FuzzyTrends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrendName = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        SeriesDiscriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SeriesDescriptions", t => t.SeriesDiscriptionId, cascadeDelete: true)
                .Index(t => t.SeriesDiscriptionId);
            
            CreateTable(
                "dbo.GranuleUXes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GranulePosition = c.Int(nullable: false),
                        LingvistUX = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DiagnosticTestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiagnosticTests", t => t.DiagnosticTestId, cascadeDelete: true)
                .Index(t => t.DiagnosticTestId);
            
            CreateTable(
                "dbo.PointTrends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartPoint = c.Int(nullable: false),
                        FinishPoint = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        SeriesDiscriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SeriesDescriptions", t => t.SeriesDiscriptionId, cascadeDelete: true)
                .Index(t => t.SeriesDiscriptionId);
            
            CreateTable(
                "dbo.RuleTrends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FuzzyTrendId = c.Int(nullable: false),
                        FuzzyLabelFromId = c.Int(nullable: false),
                        FuzzyLabelToId = c.Int(nullable: false),
                        SeriesDiscriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FuzzyLabels", t => t.FuzzyLabelFromId)
                .ForeignKey("dbo.FuzzyLabels", t => t.FuzzyLabelToId)
                .ForeignKey("dbo.FuzzyTrends", t => t.FuzzyTrendId)
                .ForeignKey("dbo.SeriesDescriptions", t => t.SeriesDiscriptionId, cascadeDelete: true)
                .Index(t => t.FuzzyTrendId)
                .Index(t => t.FuzzyLabelFromId)
                .Index(t => t.FuzzyLabelToId)
                .Index(t => t.SeriesDiscriptionId);
            
            CreateTable(
                "dbo.StatisticsByEntropies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartStateLingvistUX = c.Int(nullable: false),
                        StartStateLingvistFT = c.Int(nullable: false),
                        EndStateLingvistUX = c.Int(nullable: false),
                        EndStateLingvistFT = c.Int(nullable: false),
                        NumberSituation = c.Int(nullable: false),
                        Description = c.String(),
                        CountMeet = c.Int(nullable: false),
                        SeriesDiscriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SeriesDescriptions", t => t.SeriesDiscriptionId, cascadeDelete: true)
                .Index(t => t.SeriesDiscriptionId);
            
            CreateTable(
                "dbo.StatisticsByFuzzies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartStateFuzzyLabelId = c.Int(nullable: false),
                        StartStateFuzzyTrendId = c.Int(nullable: false),
                        EndStateFuzzyLabelId = c.Int(nullable: false),
                        EndStateFuzzyTrendId = c.Int(nullable: false),
                        NumberSituation = c.Int(nullable: false),
                        Description = c.String(),
                        CountMeet = c.Int(nullable: false),
                        SeriesDiscriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FuzzyLabels", t => t.EndStateFuzzyLabelId)
                .ForeignKey("dbo.FuzzyTrends", t => t.EndStateFuzzyTrendId)
                .ForeignKey("dbo.SeriesDescriptions", t => t.SeriesDiscriptionId, cascadeDelete: true)
                .ForeignKey("dbo.FuzzyLabels", t => t.StartStateFuzzyLabelId)
                .ForeignKey("dbo.FuzzyTrends", t => t.StartStateFuzzyTrendId)
                .Index(t => t.StartStateFuzzyLabelId)
                .Index(t => t.StartStateFuzzyTrendId)
                .Index(t => t.EndStateFuzzyLabelId)
                .Index(t => t.EndStateFuzzyTrendId)
                .Index(t => t.SeriesDiscriptionId);
            
            CreateTable(
                "dbo.PointInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiagnosticTestId = c.Int(nullable: false),
                        Value = c.Double(),
                        Date = c.DateTime(),
                        Fux = c.Double(),
                        PositionFUX = c.Boolean(),
                        IsLast = c.Boolean(nullable: false),
                        FuzzyLabelId = c.Int(),
                        FuzzyTrendId = c.Int(),
                        EntropuUX = c.Double(nullable: false),
                        EntropyFT = c.Double(nullable: false),
                        StatisticsByEntropyId = c.Int(),
                        StatisticsByFuzzyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiagnosticTests", t => t.DiagnosticTestId, cascadeDelete: true)
                .ForeignKey("dbo.FuzzyLabels", t => t.FuzzyLabelId)
                .ForeignKey("dbo.FuzzyTrends", t => t.FuzzyTrendId)
                .ForeignKey("dbo.StatisticsByEntropies", t => t.StatisticsByEntropyId)
                .ForeignKey("dbo.StatisticsByFuzzies", t => t.StatisticsByFuzzyId)
                .Index(t => t.DiagnosticTestId)
                .Index(t => t.FuzzyLabelId)
                .Index(t => t.FuzzyTrendId)
                .Index(t => t.StatisticsByEntropyId)
                .Index(t => t.StatisticsByFuzzyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PointInfoes", "StatisticsByFuzzyId", "dbo.StatisticsByFuzzies");
            DropForeignKey("dbo.PointInfoes", "StatisticsByEntropyId", "dbo.StatisticsByEntropies");
            DropForeignKey("dbo.PointInfoes", "FuzzyTrendId", "dbo.FuzzyTrends");
            DropForeignKey("dbo.PointInfoes", "FuzzyLabelId", "dbo.FuzzyLabels");
            DropForeignKey("dbo.PointInfoes", "DiagnosticTestId", "dbo.DiagnosticTests");
            DropForeignKey("dbo.StatisticsByFuzzies", "StartStateFuzzyTrendId", "dbo.FuzzyTrends");
            DropForeignKey("dbo.StatisticsByFuzzies", "StartStateFuzzyLabelId", "dbo.FuzzyLabels");
            DropForeignKey("dbo.StatisticsByFuzzies", "SeriesDiscriptionId", "dbo.SeriesDescriptions");
            DropForeignKey("dbo.StatisticsByFuzzies", "EndStateFuzzyTrendId", "dbo.FuzzyTrends");
            DropForeignKey("dbo.StatisticsByFuzzies", "EndStateFuzzyLabelId", "dbo.FuzzyLabels");
            DropForeignKey("dbo.StatisticsByEntropies", "SeriesDiscriptionId", "dbo.SeriesDescriptions");
            DropForeignKey("dbo.RuleTrends", "SeriesDiscriptionId", "dbo.SeriesDescriptions");
            DropForeignKey("dbo.RuleTrends", "FuzzyTrendId", "dbo.FuzzyTrends");
            DropForeignKey("dbo.RuleTrends", "FuzzyLabelToId", "dbo.FuzzyLabels");
            DropForeignKey("dbo.RuleTrends", "FuzzyLabelFromId", "dbo.FuzzyLabels");
            DropForeignKey("dbo.PointTrends", "SeriesDiscriptionId", "dbo.SeriesDescriptions");
            DropForeignKey("dbo.DiagnosticTests", "SeriesDiscriptionId", "dbo.SeriesDescriptions");
            DropForeignKey("dbo.GranuleUXes", "DiagnosticTestId", "dbo.DiagnosticTests");
            DropForeignKey("dbo.GranuleFuzzies", "FuzzyTrendId", "dbo.FuzzyTrends");
            DropForeignKey("dbo.FuzzyTrends", "SeriesDiscriptionId", "dbo.SeriesDescriptions");
            DropForeignKey("dbo.GranuleFuzzies", "FuzzyLabelId", "dbo.FuzzyLabels");
            DropForeignKey("dbo.FuzzyLabels", "SeriesDiscriptionId", "dbo.SeriesDescriptions");
            DropForeignKey("dbo.GranuleFuzzies", "DiagnosticTestId", "dbo.DiagnosticTests");
            DropForeignKey("dbo.GranuleFTs", "DiagnosticTestId", "dbo.DiagnosticTests");
            DropForeignKey("dbo.GranuleEntropies", "DiagnosticTestId", "dbo.DiagnosticTests");
            DropForeignKey("dbo.DiagnosticTestRecords", "DiagnosticTestId", "dbo.DiagnosticTests");
            DropForeignKey("dbo.DiagnosticTestRecords", "AnomalyInfoId", "dbo.AnomalyInfoes");
            DropForeignKey("dbo.AnomalyInfoes", "SeriesDiscriptionId", "dbo.SeriesDescriptions");
            DropIndex("dbo.PointInfoes", new[] { "StatisticsByFuzzyId" });
            DropIndex("dbo.PointInfoes", new[] { "StatisticsByEntropyId" });
            DropIndex("dbo.PointInfoes", new[] { "FuzzyTrendId" });
            DropIndex("dbo.PointInfoes", new[] { "FuzzyLabelId" });
            DropIndex("dbo.PointInfoes", new[] { "DiagnosticTestId" });
            DropIndex("dbo.StatisticsByFuzzies", new[] { "SeriesDiscriptionId" });
            DropIndex("dbo.StatisticsByFuzzies", new[] { "EndStateFuzzyTrendId" });
            DropIndex("dbo.StatisticsByFuzzies", new[] { "EndStateFuzzyLabelId" });
            DropIndex("dbo.StatisticsByFuzzies", new[] { "StartStateFuzzyTrendId" });
            DropIndex("dbo.StatisticsByFuzzies", new[] { "StartStateFuzzyLabelId" });
            DropIndex("dbo.StatisticsByEntropies", new[] { "SeriesDiscriptionId" });
            DropIndex("dbo.RuleTrends", new[] { "SeriesDiscriptionId" });
            DropIndex("dbo.RuleTrends", new[] { "FuzzyLabelToId" });
            DropIndex("dbo.RuleTrends", new[] { "FuzzyLabelFromId" });
            DropIndex("dbo.RuleTrends", new[] { "FuzzyTrendId" });
            DropIndex("dbo.PointTrends", new[] { "SeriesDiscriptionId" });
            DropIndex("dbo.GranuleUXes", new[] { "DiagnosticTestId" });
            DropIndex("dbo.FuzzyTrends", new[] { "SeriesDiscriptionId" });
            DropIndex("dbo.FuzzyLabels", new[] { "SeriesDiscriptionId" });
            DropIndex("dbo.GranuleFuzzies", new[] { "DiagnosticTestId" });
            DropIndex("dbo.GranuleFuzzies", new[] { "FuzzyTrendId" });
            DropIndex("dbo.GranuleFuzzies", new[] { "FuzzyLabelId" });
            DropIndex("dbo.GranuleFTs", new[] { "DiagnosticTestId" });
            DropIndex("dbo.GranuleEntropies", new[] { "DiagnosticTestId" });
            DropIndex("dbo.DiagnosticTestRecords", new[] { "DiagnosticTestId" });
            DropIndex("dbo.DiagnosticTestRecords", new[] { "AnomalyInfoId" });
            DropIndex("dbo.DiagnosticTests", new[] { "SeriesDiscriptionId" });
            DropIndex("dbo.AnomalyInfoes", new[] { "SeriesDiscriptionId" });
            DropTable("dbo.PointInfoes");
            DropTable("dbo.StatisticsByFuzzies");
            DropTable("dbo.StatisticsByEntropies");
            DropTable("dbo.RuleTrends");
            DropTable("dbo.PointTrends");
            DropTable("dbo.GranuleUXes");
            DropTable("dbo.FuzzyTrends");
            DropTable("dbo.FuzzyLabels");
            DropTable("dbo.GranuleFuzzies");
            DropTable("dbo.GranuleFTs");
            DropTable("dbo.GranuleEntropies");
            DropTable("dbo.DiagnosticTestRecords");
            DropTable("dbo.DiagnosticTests");
            DropTable("dbo.SeriesDescriptions");
            DropTable("dbo.AnomalyInfoes");
        }
    }
}
