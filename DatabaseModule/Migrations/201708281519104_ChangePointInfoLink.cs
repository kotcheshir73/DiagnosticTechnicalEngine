namespace DatabaseModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePointInfoLink : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DiagnosticTests", "FirstPointId", "dbo.PointInfoes");
            DropForeignKey("dbo.DiagnosticTests", "SecondPointId", "dbo.PointInfoes");
            DropIndex("dbo.DiagnosticTests", new[] { "FirstPointId" });
            DropIndex("dbo.DiagnosticTests", new[] { "SecondPointId" });
            AddColumn("dbo.PointInfoes", "IsLast", c => c.Boolean(nullable: false));
            DropColumn("dbo.DiagnosticTests", "FirstPointId");
            DropColumn("dbo.DiagnosticTests", "SecondPointId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DiagnosticTests", "SecondPointId", c => c.Int());
            AddColumn("dbo.DiagnosticTests", "FirstPointId", c => c.Int());
            DropColumn("dbo.PointInfoes", "IsLast");
            CreateIndex("dbo.DiagnosticTests", "SecondPointId");
            CreateIndex("dbo.DiagnosticTests", "FirstPointId");
            AddForeignKey("dbo.DiagnosticTests", "SecondPointId", "dbo.PointInfoes", "Id");
            AddForeignKey("dbo.DiagnosticTests", "FirstPointId", "dbo.PointInfoes", "Id");
        }
    }
}
