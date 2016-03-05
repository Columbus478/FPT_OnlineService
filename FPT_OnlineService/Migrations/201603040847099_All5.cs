namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuspendSubjectForms", "NotAllSubject", c => c.String());
            DropColumn("dbo.CourseRegForms", "CourseAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseRegForms", "CourseAvailable", c => c.String());
            DropColumn("dbo.SuspendSubjectForms", "NotAllSubject");
        }
    }
}
