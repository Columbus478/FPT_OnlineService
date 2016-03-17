namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RequestForms", "Description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RequestForms", "Description", c => c.String(nullable: false, maxLength: 240));
        }
    }
}
