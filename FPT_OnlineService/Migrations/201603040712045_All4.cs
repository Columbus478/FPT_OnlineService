namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseRegForms", "CourseAvailable", c => c.String());
            AddColumn("dbo.CourseRegForms", "TuitionFee", c => c.String());
            AddColumn("dbo.Forms", "ApprovedBy", c => c.String());
            AddColumn("dbo.DropOutForms", "LibraryStatus", c => c.String());
            AddColumn("dbo.DropOutForms", "AccountStatus", c => c.String());
            AddColumn("dbo.DropOutForms", "AcademicHeadEndorse", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DropOutForms", "AcademicHeadEndorse");
            DropColumn("dbo.DropOutForms", "AccountStatus");
            DropColumn("dbo.DropOutForms", "LibraryStatus");
            DropColumn("dbo.Forms", "ApprovedBy");
            DropColumn("dbo.CourseRegForms", "TuitionFee");
            DropColumn("dbo.CourseRegForms", "CourseAvailable");
        }
    }
}
