namespace FPT_OnlineService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseRegForms",
                c => new
                    {
                        FormID = c.Int(nullable: false),
                        StudentPhone = c.Int(nullable: false),
                        SubjectCode = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        TuitionFee = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FormID)
                .ForeignKey("dbo.Forms", t => t.FormID)
                .Index(t => t.FormID);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Date = c.DateTime(nullable: false),
                        CurrentDesk = c.String(),
                        Flow = c.String(),
                        Status = c.String(),
                        IsWeekBefore = c.Boolean(nullable: false),
                        EndorsedBy = c.String(),
                        ApprovalDate = c.String(),
                        RollNo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.RollNo)
                .Index(t => t.RollNo);
            
            CreateTable(
                "dbo.DropOutForms",
                c => new
                    {
                        FormID = c.Int(nullable: false),
                        Class = c.String(nullable: false, maxLength: 10),
                        MethodPayment = c.String(nullable: false),
                        DropOutDate = c.String(nullable: false),
                        Reason = c.String(nullable: false),
                        LibraryStatus = c.String(),
                        AccountStatus = c.String(),
                        AcademicHeadEndorse = c.String(),
                    })
                .PrimaryKey(t => t.FormID)
                .ForeignKey("dbo.Forms", t => t.FormID)
                .Index(t => t.FormID);
            
            CreateTable(
                "dbo.RequestForms",
                c => new
                    {
                        FormID = c.Int(nullable: false),
                        RequestTitle = c.String(nullable: false),
                        StudentPhone = c.Int(nullable: false),
                        Class = c.String(nullable: false, maxLength: 10),
                        Description = c.String(nullable: false),
                        ProcessedBy = c.String(),
                        ApprovalReason = c.String(),
                        ToDepartment = c.String(),
                        ReceivedBy = c.String(),
                    })
                .PrimaryKey(t => t.FormID)
                .ForeignKey("dbo.Forms", t => t.FormID)
                .Index(t => t.FormID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        UserId = c.String(maxLength: 128),
                        RollNo = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.RollNo)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 256),
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        UserId = c.String(maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 128),
                        StaffRole = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserName)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SuspendSemesterForms",
                c => new
                    {
                        FormID = c.Int(nullable: false),
                        StudentPhone = c.Int(nullable: false),
                        SemesterSeason = c.String(nullable: false),
                        TuitionFee = c.Boolean(nullable: false),
                        PreviousSemester = c.String(),
                        TwoPrevSemester = c.String(),
                    })
                .PrimaryKey(t => t.FormID)
                .ForeignKey("dbo.Forms", t => t.FormID)
                .Index(t => t.FormID);
            
            CreateTable(
                "dbo.SuspendSubjectForms",
                c => new
                    {
                        FormID = c.Int(nullable: false),
                        StudentPhone = c.Int(nullable: false),
                        SemesterSeason = c.String(nullable: false),
                        SubjectCode = c.String(nullable: false),
                        SubjectName = c.String(nullable: false),
                        NotAllSubject = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FormID)
                .ForeignKey("dbo.Forms", t => t.FormID)
                .Index(t => t.FormID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CourseRegForms", "FormID", "dbo.Forms");
            DropForeignKey("dbo.SuspendSubjectForms", "FormID", "dbo.Forms");
            DropForeignKey("dbo.SuspendSemesterForms", "FormID", "dbo.Forms");
            DropForeignKey("dbo.Forms", "RollNo", "dbo.Students");
            DropForeignKey("dbo.Students", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Staffs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RequestForms", "FormID", "dbo.Forms");
            DropForeignKey("dbo.DropOutForms", "FormID", "dbo.Forms");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SuspendSubjectForms", new[] { "FormID" });
            DropIndex("dbo.SuspendSemesterForms", new[] { "FormID" });
            DropIndex("dbo.Staffs", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Students", new[] { "UserId" });
            DropIndex("dbo.RequestForms", new[] { "FormID" });
            DropIndex("dbo.DropOutForms", new[] { "FormID" });
            DropIndex("dbo.Forms", new[] { "RollNo" });
            DropIndex("dbo.CourseRegForms", new[] { "FormID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SuspendSubjectForms");
            DropTable("dbo.SuspendSemesterForms");
            DropTable("dbo.Staffs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Students");
            DropTable("dbo.RequestForms");
            DropTable("dbo.DropOutForms");
            DropTable("dbo.Forms");
            DropTable("dbo.CourseRegForms");
        }
    }
}
