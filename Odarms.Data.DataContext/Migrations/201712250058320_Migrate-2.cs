namespace Odarms.Data.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        RestaurantId = c.Long(nullable: false),
                        EmployeeId = c.Long(),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Long(nullable: false),
                        RestaurantId = c.Long(),
                        DepartmentId = c.Long(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Department", t => t.EmployeeId)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId)
                .Index(t => t.EmployeeId)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.EmployeeFamilyData",
                c => new
                    {
                        EmployeeFamilyDataId = c.Long(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Relationship = c.String(nullable: false),
                        EmployeeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeFamilyDataId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeeMedicalData",
                c => new
                    {
                        EmployeeMedicalDataId = c.Long(nullable: false, identity: true),
                        Genotype = c.String(nullable: false),
                        BloodGroup = c.String(nullable: false),
                        EmployeeId = c.Long(nullable: false),
                        DepartmentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeMedicalDataId)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.EmployeePersonalData",
                c => new
                    {
                        EmployeePersonalDataId = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        POB = c.String(nullable: false),
                        DOB = c.String(nullable: false),
                        PrimaryAddress = c.String(nullable: false),
                        SecondaryAddress = c.String(),
                        Gender = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        HomePhone = c.String(nullable: false),
                        MobilePhone = c.String(),
                        WorkPhone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        MaritalStatus = c.String(nullable: false),
                        EmployeeImage = c.String(),
                        EmployeeId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                        LgaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeePersonalDataId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Lga", t => t.LgaId, cascadeDelete: true)
                .ForeignKey("dbo.State", t => t.StateId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.StateId)
                .Index(t => t.LgaId);
            
            CreateTable(
                "dbo.Lga",
                c => new
                    {
                        LgaId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LgaId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.EmployeeWorkData",
                c => new
                    {
                        EmployeeWorkDataId = c.Long(nullable: false, identity: true),
                        EmploymentDate = c.DateTime(nullable: false),
                        EmployementStatus = c.String(nullable: false),
                        EmploymentPosistionId = c.Long(nullable: false),
                        EmployeeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeWorkDataId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.EmploymentPosition", t => t.EmploymentPosistionId, cascadeDelete: true)
                .Index(t => t.EmploymentPosistionId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmploymentPosition",
                c => new
                    {
                        EmploymentPositionId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Income = c.Long(nullable: false),
                        SeniorMember = c.Boolean(nullable: false),
                        RestaurantId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.EmploymentPositionId)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Department", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.Employee", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.EmployeeWorkData", "EmploymentPosistionId", "dbo.EmploymentPosition");
            DropForeignKey("dbo.EmploymentPosition", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.EmployeeWorkData", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.EmployeePersonalData", "StateId", "dbo.State");
            DropForeignKey("dbo.EmployeePersonalData", "LgaId", "dbo.Lga");
            DropForeignKey("dbo.EmployeePersonalData", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.EmployeeMedicalData", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.EmployeeMedicalData", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.EmployeeFamilyData", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "EmployeeId", "dbo.Department");
            DropIndex("dbo.EmploymentPosition", new[] { "RestaurantId" });
            DropIndex("dbo.EmployeeWorkData", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeWorkData", new[] { "EmploymentPosistionId" });
            DropIndex("dbo.EmployeePersonalData", new[] { "LgaId" });
            DropIndex("dbo.EmployeePersonalData", new[] { "StateId" });
            DropIndex("dbo.EmployeePersonalData", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeMedicalData", new[] { "DepartmentId" });
            DropIndex("dbo.EmployeeMedicalData", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeFamilyData", new[] { "EmployeeId" });
            DropIndex("dbo.Employee", new[] { "RestaurantId" });
            DropIndex("dbo.Employee", new[] { "EmployeeId" });
            DropIndex("dbo.Department", new[] { "RestaurantId" });
            DropTable("dbo.EmploymentPosition");
            DropTable("dbo.EmployeeWorkData");
            DropTable("dbo.State");
            DropTable("dbo.Lga");
            DropTable("dbo.EmployeePersonalData");
            DropTable("dbo.EmployeeMedicalData");
            DropTable("dbo.EmployeeFamilyData");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
