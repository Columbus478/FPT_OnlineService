namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SuspendSemesterForms", "TuitionFee", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SuspendSemesterForms", "TuitionFee", c => c.String());
        }
    }
}
