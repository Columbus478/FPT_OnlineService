namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tuition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuspendSemesterForms", "TuitionFee", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SuspendSemesterForms", "TuitionFee");
        }
    }
}
