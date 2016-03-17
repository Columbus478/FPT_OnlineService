namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuspendSemesterForms", "SemesterName", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.SuspendSemesterForms", "SemesterName");
            AddForeignKey("dbo.SuspendSemesterForms", "SemesterName", "dbo.Semesters", "Name", cascadeDelete: true);
            DropColumn("dbo.SuspendSemesterForms", "Semester");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SuspendSemesterForms", "Semester", c => c.String(nullable: false));
            DropForeignKey("dbo.SuspendSemesterForms", "SemesterName", "dbo.Semesters");
            DropIndex("dbo.SuspendSemesterForms", new[] { "SemesterName" });
            DropColumn("dbo.SuspendSemesterForms", "SemesterName");
        }
    }
}
