namespace Odarms.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate7 : DbMigration
    {
        public override void Up()
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
                        RestaurantId = c.Long(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateLastModified = c.DateTime(nullable: false),
                        LastModifiedBy = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.AppUserId)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            AddColumn("dbo.Package", "CreatedBy", c => c.Long(nullable: false));
            AddColumn("dbo.Package", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Package", "DateLastModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Package", "LastModifiedBy", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUser", "RestaurantId", "dbo.Restaurant");
            DropIndex("dbo.AppUser", new[] { "RestaurantId" });
            DropColumn("dbo.Package", "LastModifiedBy");
            DropColumn("dbo.Package", "DateLastModified");
            DropColumn("dbo.Package", "DateCreated");
            DropColumn("dbo.Package", "CreatedBy");
            DropTable("dbo.AppUser");
        }
    }
}
