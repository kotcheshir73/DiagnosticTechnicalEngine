namespace DatabaseModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DiagnosticTestRecords", "Probability");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DiagnosticTestRecords", "Probability", c => c.Double());
        }
    }
}
