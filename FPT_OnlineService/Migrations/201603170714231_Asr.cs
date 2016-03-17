namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Asr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseRegForms", "CoursesAvailable", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseRegForms", "CoursesAvailable");
        }
    }
}
