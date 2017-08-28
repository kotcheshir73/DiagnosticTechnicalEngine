namespace DatabaseModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDiagnosticTestByPoints2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DiagnosticTests", "FirstPointId", "dbo.PointInfoes");
            DropForeignKey("dbo.DiagnosticTests", "SecondPointId", "dbo.PointInfoes");
            DropIndex("dbo.DiagnosticTests", new[] { "FirstPointId" });
            DropIndex("dbo.DiagnosticTests", new[] { "SecondPointId" });
            AlterColumn("dbo.DiagnosticTests", "FirstPointId", c => c.Int());
            AlterColumn("dbo.DiagnosticTests", "SecondPointId", c => c.Int());
            CreateIndex("dbo.DiagnosticTests", "FirstPointId");
            CreateIndex("dbo.DiagnosticTests", "SecondPointId");
            AddForeignKey("dbo.DiagnosticTests", "FirstPointId", "dbo.PointInfoes", "Id");
            AddForeignKey("dbo.DiagnosticTests", "SecondPointId", "dbo.PointInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiagnosticTests", "SecondPointId", "dbo.PointInfoes");
            DropForeignKey("dbo.DiagnosticTests", "FirstPointId", "dbo.PointInfoes");
            DropIndex("dbo.DiagnosticTests", new[] { "SecondPointId" });
            DropIndex("dbo.DiagnosticTests", new[] { "FirstPointId" });
            AlterColumn("dbo.DiagnosticTests", "SecondPointId", c => c.Int(nullable: false));
            AlterColumn("dbo.DiagnosticTests", "FirstPointId", c => c.Int(nullable: false));
            CreateIndex("dbo.DiagnosticTests", "SecondPointId");
            CreateIndex("dbo.DiagnosticTests", "FirstPointId");
            AddForeignKey("dbo.DiagnosticTests", "SecondPointId", "dbo.PointInfoes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DiagnosticTests", "FirstPointId", "dbo.PointInfoes", "Id", cascadeDelete: false);
        }
    }
}
