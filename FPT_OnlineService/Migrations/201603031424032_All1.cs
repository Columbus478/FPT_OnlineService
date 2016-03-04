namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuspendSemesterForms", "PreviousSemester", c => c.String());
            AddColumn("dbo.SuspendSemesterForms", "TwoPrevSemester", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SuspendSemesterForms", "TwoPrevSemester");
            DropColumn("dbo.SuspendSemesterForms", "PreviousSemester");
        }
    }
}
