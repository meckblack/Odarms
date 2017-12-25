namespace Odarms.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lga", "StateId", c => c.Long());
            CreateIndex("dbo.Lga", "StateId");
            AddForeignKey("dbo.Lga", "StateId", "dbo.State", "StateId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lga", "StateId", "dbo.State");
            DropIndex("dbo.Lga", new[] { "StateId" });
            DropColumn("dbo.Lga", "StateId");
        }
    }
}
