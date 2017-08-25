namespace DatabaseModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDiagnosticTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiagnosticTests", "TestNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiagnosticTests", "TestNumber");
        }
    }
}
