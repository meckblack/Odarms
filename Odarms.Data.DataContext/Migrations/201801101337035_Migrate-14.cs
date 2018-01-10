namespace Odarms.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeBankData",
                c => new
                    {
                        EmployeeBankDataId = c.Long(nullable: false, identity: true),
                        BankId = c.Long(nullable: false),
                        AccountFirstName = c.String(nullable: false),
                        AccountMiddleName = c.String(),
                        AccountLastName = c.String(nullable: false),
                        AccountNumber = c.String(nullable: false, maxLength: 11),
                        AccountType = c.String(nullable: false),
                        FakeId = c.Long(nullable: false),
                        EmployeeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeBankDataId)
                .ForeignKey("dbo.Bank", t => t.BankId, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.BankId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Bank",
                c => new
                    {
                        BankId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BankId);
            
            AddColumn("dbo.EmployeeWorkData", "EmploymentStatus", c => c.String(nullable: false));
            DropColumn("dbo.EmployeeWorkData", "EmployementStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeWorkData", "EmployementStatus", c => c.String(nullable: false));
            DropForeignKey("dbo.EmployeeBankData", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.EmployeeBankData", "BankId", "dbo.Bank");
            DropIndex("dbo.EmployeeBankData", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeBankData", new[] { "BankId" });
            DropColumn("dbo.EmployeeWorkData", "EmploymentStatus");
            DropTable("dbo.Bank");
            DropTable("dbo.EmployeeBankData");
        }
    }
}
