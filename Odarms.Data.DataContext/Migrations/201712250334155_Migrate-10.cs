namespace Odarms.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate10 : DbMigration
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
                        RestaurantId = c.Long(),
                        EmployeeId = c.Long(),
                        RoleId = c.Long(),
                        CreatedBy = c.Long(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateLastModified = c.DateTime(nullable: false),
                        LastModifiedBy = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.AppUserId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.RestaurantId)
                .Index(t => t.EmployeeId)
                .Index(t => t.RoleId);
            
            
        }
        
        public override void Down()
        {
           
        }
    }
}
