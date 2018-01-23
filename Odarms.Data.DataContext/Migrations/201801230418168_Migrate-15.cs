namespace Odarms.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate15 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Package", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Package", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Package", "Type", c => c.String());
            AlterColumn("dbo.Package", "Description", c => c.String());
        }
    }
}
