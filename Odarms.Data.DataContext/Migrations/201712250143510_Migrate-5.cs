namespace Odarms.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurant", "SubscriprionStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Restaurant", "SubscriptonEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Restaurant", "SubscriptionDuration", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurant", "SubscriptionDuration");
            DropColumn("dbo.Restaurant", "SubscriptonEndDate");
            DropColumn("dbo.Restaurant", "SubscriprionStartDate");
        }
    }
}
