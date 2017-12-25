namespace Odarms.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppUser", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.AppUser", "RoleId", "dbo.Role");
            DropIndex("dbo.AppUser", new[] { "RestaurantId" });
            DropIndex("dbo.AppUser", new[] { "RoleId" });
            DropTable("dbo.AppUser");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AppUser",
                c => new
                    {
                        AppUserId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MiddleName = c.String(),
                        Email = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ComfirmPassword = c.String(nullable: false),
                        RestaurantId = c.Long(),
                        RoleId = c.Long(),
                        CreatedBy = c.Long(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateLastModified = c.DateTime(nullable: false),
                        LastModifiedBy = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.AppUserId);
            
            CreateIndex("dbo.AppUser", "RoleId");
            CreateIndex("dbo.AppUser", "RestaurantId");
            AddForeignKey("dbo.AppUser", "RoleId", "dbo.Role", "RoleId");
            AddForeignKey("dbo.AppUser", "RestaurantId", "dbo.Restaurant", "RestaurantId");
        }
    }
}
