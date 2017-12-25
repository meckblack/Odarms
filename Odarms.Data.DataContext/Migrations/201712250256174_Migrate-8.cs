namespace Odarms.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppUser", "RestaurantId", "dbo.Restaurant");
            DropIndex("dbo.AppUser", new[] { "RestaurantId" });
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ManagePackages = c.Boolean(nullable: false),
                        ManageRestaurants = c.Boolean(nullable: false),
                        ManageDepartments = c.Boolean(nullable: false),
                        ManageVendors = c.Boolean(nullable: false),
                        ManageEmployees = c.Boolean(nullable: false),
                        RestaurantId = c.Long(),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId)
                .Index(t => t.RestaurantId);
            
            AddColumn("dbo.AppUser", "RoleId", c => c.Long());
            AddColumn("dbo.Employee", "RoleId", c => c.Long(nullable: false));
            AlterColumn("dbo.AppUser", "RestaurantId", c => c.Long());
            CreateIndex("dbo.AppUser", "RestaurantId");
            CreateIndex("dbo.AppUser", "RoleId");
            CreateIndex("dbo.Employee", "RoleId");
            AddForeignKey("dbo.AppUser", "RoleId", "dbo.Role", "RoleId");
            AddForeignKey("dbo.Employee", "RoleId", "dbo.Role", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.AppUser", "RestaurantId", "dbo.Restaurant", "RestaurantId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUser", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.Employee", "RoleId", "dbo.Role");
            DropForeignKey("dbo.AppUser", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Role", "RestaurantId", "dbo.Restaurant");
            DropIndex("dbo.Employee", new[] { "RoleId" });
            DropIndex("dbo.Role", new[] { "RestaurantId" });
            DropIndex("dbo.AppUser", new[] { "RoleId" });
            DropIndex("dbo.AppUser", new[] { "RestaurantId" });
            AlterColumn("dbo.AppUser", "RestaurantId", c => c.Long(nullable: false));
            DropColumn("dbo.Employee", "RoleId");
            DropColumn("dbo.AppUser", "RoleId");
            DropTable("dbo.Role");
            CreateIndex("dbo.AppUser", "RestaurantId");
            AddForeignKey("dbo.AppUser", "RestaurantId", "dbo.Restaurant", "RestaurantId", cascadeDelete: true);
        }
    }
}
