namespace Odarms.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantStructure",
                c => new
                    {
                        RestaurantStructureId = c.Long(nullable: false, identity: true),
                        Department = c.Boolean(nullable: false),
                        RestaurantId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantStructureId)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.SystemStatistic",
                c => new
                    {
                        SystemStatisticId = c.Long(nullable: false, identity: true),
                        Action = c.String(),
                        DateOccured = c.DateTime(nullable: false),
                        LoggedInUserId = c.Long(),
                        RestaurantId = c.Long(),
                    })
                .PrimaryKey(t => t.SystemStatisticId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantStructure", "RestaurantId", "dbo.Restaurant");
            DropIndex("dbo.RestaurantStructure", new[] { "RestaurantId" });
            DropTable("dbo.SystemStatistic");
            DropTable("dbo.RestaurantStructure");
        }
    }
}
