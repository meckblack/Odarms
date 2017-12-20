namespace Odarms.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurant",
                c => new
                    {
                        RestaurantId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Motto = c.String(),
                        Logo = c.String(),
                        State = c.String(nullable: false),
                        LGA = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        ContactEmail = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restaurant");
        }
    }
}
