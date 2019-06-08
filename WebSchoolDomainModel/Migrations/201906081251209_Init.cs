namespace WebSchoolDomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        DisciplineId = c.Int(nullable: false, identity: true),
                        DisciplineName = c.String(),
                    })
                .PrimaryKey(t => t.DisciplineId);
            
            CreateTable(
                "dbo.EducationalClasses",
                c => new
                    {
                        EducationalClassId = c.Int(nullable: false, identity: true),
                        EducationalClassLetter = c.String(),
                        EducationalClassNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EducationalClassId);
            
            CreateTable(
                "dbo.Pupils",
                c => new
                    {
                        PupilId = c.Int(nullable: false, identity: true),
                        PupilLastName = c.String(),
                        PupilFirstName = c.String(),
                        PupilMiddleName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        EducationalClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PupilId)
                .ForeignKey("dbo.EducationalClasses", t => t.EducationalClassId)
                .Index(t => t.EducationalClassId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeLastName = c.String(),
                        EmployeeFirstName = c.String(),
                        EmployeeMiddleName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        SchoolId = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(),
                    })
                .PrimaryKey(t => t.SchoolId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.EducationalClassDisciplines",
                c => new
                    {
                        EducationalClass_EducationalClassId = c.Int(nullable: false),
                        Discipline_DisciplineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EducationalClass_EducationalClassId, t.Discipline_DisciplineId })
                .ForeignKey("dbo.EducationalClasses", t => t.EducationalClass_EducationalClassId)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_DisciplineId)
                .Index(t => t.EducationalClass_EducationalClassId)
                .Index(t => t.Discipline_DisciplineId);
            
            CreateTable(
                "dbo.EmployeeDisciplines",
                c => new
                    {
                        Employee_EmployeeId = c.Int(nullable: false),
                        Discipline_DisciplineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeId, t.Discipline_DisciplineId })
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_DisciplineId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Discipline_DisciplineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.EmployeeDisciplines", "Discipline_DisciplineId", "dbo.Disciplines");
            DropForeignKey("dbo.EmployeeDisciplines", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Pupils", "EducationalClassId", "dbo.EducationalClasses");
            DropForeignKey("dbo.EducationalClassDisciplines", "Discipline_DisciplineId", "dbo.Disciplines");
            DropForeignKey("dbo.EducationalClassDisciplines", "EducationalClass_EducationalClassId", "dbo.EducationalClasses");
            DropIndex("dbo.EmployeeDisciplines", new[] { "Discipline_DisciplineId" });
            DropIndex("dbo.EmployeeDisciplines", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.EducationalClassDisciplines", new[] { "Discipline_DisciplineId" });
            DropIndex("dbo.EducationalClassDisciplines", new[] { "EducationalClass_EducationalClassId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Pupils", new[] { "EducationalClassId" });
            DropTable("dbo.EmployeeDisciplines");
            DropTable("dbo.EducationalClassDisciplines");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Schools");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Employees");
            DropTable("dbo.Pupils");
            DropTable("dbo.EducationalClasses");
            DropTable("dbo.Disciplines");
        }
    }
}
