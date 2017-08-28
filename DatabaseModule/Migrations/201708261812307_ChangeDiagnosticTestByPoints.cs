namespace DatabaseModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDiagnosticTestByPoints : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DiagnosticTests", "FirstPoint_Id", "dbo.PointInfoes");
            DropForeignKey("dbo.DiagnosticTests", "SecondPoint_Id", "dbo.PointInfoes");
            DropIndex("dbo.DiagnosticTests", new[] { "FirstPoint_Id" });
            DropIndex("dbo.DiagnosticTests", new[] { "SecondPoint_Id" });
            RenameColumn(table: "dbo.DiagnosticTests", name: "FirstPoint_Id", newName: "FirstPointId");
            RenameColumn(table: "dbo.DiagnosticTests", name: "SecondPoint_Id", newName: "SecondPointId");
            AlterColumn("dbo.DiagnosticTests", "FirstPointId", c => c.Int(nullable: false));
            AlterColumn("dbo.DiagnosticTests", "SecondPointId", c => c.Int(nullable: false));
            CreateIndex("dbo.DiagnosticTests", "FirstPointId");
            CreateIndex("dbo.DiagnosticTests", "SecondPointId");
            AddForeignKey("dbo.DiagnosticTests", "FirstPointId", "dbo.PointInfoes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DiagnosticTests", "SecondPointId", "dbo.PointInfoes", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiagnosticTests", "SecondPointId", "dbo.PointInfoes");
            DropForeignKey("dbo.DiagnosticTests", "FirstPointId", "dbo.PointInfoes");
            DropIndex("dbo.DiagnosticTests", new[] { "SecondPointId" });
            DropIndex("dbo.DiagnosticTests", new[] { "FirstPointId" });
            AlterColumn("dbo.DiagnosticTests", "SecondPointId", c => c.Int());
            AlterColumn("dbo.DiagnosticTests", "FirstPointId", c => c.Int());
            RenameColumn(table: "dbo.DiagnosticTests", name: "SecondPointId", newName: "SecondPoint_Id");
            RenameColumn(table: "dbo.DiagnosticTests", name: "FirstPointId", newName: "FirstPoint_Id");
            CreateIndex("dbo.DiagnosticTests", "SecondPoint_Id");
            CreateIndex("dbo.DiagnosticTests", "FirstPoint_Id");
            AddForeignKey("dbo.DiagnosticTests", "SecondPoint_Id", "dbo.PointInfoes", "Id");
            AddForeignKey("dbo.DiagnosticTests", "FirstPoint_Id", "dbo.PointInfoes", "Id");
        }
    }
}
