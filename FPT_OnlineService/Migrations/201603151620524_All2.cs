namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuspendSemesterForms", "Semester_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SuspendSemesterForms", "Semester_Name");
        }
    }
}
