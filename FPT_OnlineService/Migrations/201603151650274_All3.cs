namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuspendSemesterForms", "SemesterId", c => c.Int(nullable: false));
            DropColumn("dbo.SuspendSemesterForms", "Semester_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SuspendSemesterForms", "Semester_Name", c => c.String());
            DropColumn("dbo.SuspendSemesterForms", "SemesterId");
        }
    }
}
