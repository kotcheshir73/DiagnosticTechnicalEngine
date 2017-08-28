namespace DatabaseModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGranuleFuzzy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GranuleFuzzies", "FuzzyLabelId", c => c.Int(nullable: false));
            AddColumn("dbo.GranuleFuzzies", "FuzzyTrendId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GranuleFuzzies", "FuzzyTrendId");
            DropColumn("dbo.GranuleFuzzies", "FuzzyLabelId");
        }
    }
}
