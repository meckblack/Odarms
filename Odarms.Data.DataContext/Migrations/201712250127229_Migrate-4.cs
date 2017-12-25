namespace Odarms.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Package",
                c => new
                    {
                        PackageId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Amount = c.Double(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.PackageId);
            
            AddColumn("dbo.Restaurant", "PackageId", c => c.Long());
            CreateIndex("dbo.Restaurant", "PackageId");
            AddForeignKey("dbo.Restaurant", "PackageId", "dbo.Package", "PackageId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurant", "PackageId", "dbo.Package");
            DropIndex("dbo.Restaurant", new[] { "PackageId" });
            DropColumn("dbo.Restaurant", "PackageId");
            DropTable("dbo.Package");
        }
    }
}
