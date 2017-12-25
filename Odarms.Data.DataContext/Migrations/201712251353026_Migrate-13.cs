namespace Odarms.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurant", "SetUpStatus", c => c.String());
            AddColumn("dbo.Restaurant", "AccessCode", c => c.String());
            AddColumn("dbo.Restaurant", "RegistrationNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurant", "RegistrationNumber");
            DropColumn("dbo.Restaurant", "AccessCode");
            DropColumn("dbo.Restaurant", "SetUpStatus");
        }
    }
}
