namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuspendSubjectForms", "SemesterName", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.SuspendSubjectForms", "SemesterName");
            AddForeignKey("dbo.SuspendSubjectForms", "SemesterName", "dbo.Semesters", "Name", cascadeDelete: true);
            DropColumn("dbo.SuspendSemesterForms", "SemesterId");
            DropColumn("dbo.SuspendSubjectForms", "Semester");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SuspendSubjectForms", "Semester", c => c.String(nullable: false));
            AddColumn("dbo.SuspendSemesterForms", "SemesterId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SuspendSubjectForms", "SemesterName", "dbo.Semesters");
            DropIndex("dbo.SuspendSubjectForms", new[] { "SemesterName" });
            DropColumn("dbo.SuspendSubjectForms", "SemesterName");
        }
    }
}
