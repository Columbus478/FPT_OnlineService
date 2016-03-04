namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuspendSubjectForms", "SubjectCode", c => c.String(nullable: false));
            AddColumn("dbo.SuspendSubjectForms", "SubjectName", c => c.String(nullable: false));
            DropColumn("dbo.RequestForms", "StudentEmail");
            DropColumn("dbo.RequestForms", "Batch");
            DropColumn("dbo.SuspendSubjectForms", "SemesterYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SuspendSubjectForms", "SemesterYear", c => c.String(nullable: false));
            AddColumn("dbo.RequestForms", "Batch", c => c.String(nullable: false));
            AddColumn("dbo.RequestForms", "StudentEmail", c => c.Int(nullable: false));
            DropColumn("dbo.SuspendSubjectForms", "SubjectName");
            DropColumn("dbo.SuspendSubjectForms", "SubjectCode");
        }
    }
}
