namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Forms", "isWeekBefore", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Forms", "isWeekBefore");
        }
    }
}
