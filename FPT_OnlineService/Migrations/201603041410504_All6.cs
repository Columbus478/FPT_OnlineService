namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DropOutForms", "AcademicHeadEndorse", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DropOutForms", "AcademicHeadEndorse", c => c.String(nullable: false));
        }
    }
}
