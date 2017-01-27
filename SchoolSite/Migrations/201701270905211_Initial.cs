namespace SchoolSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                        Description = c.String(),
                        CurrentSubject_SubjectId = c.Int(),
                        Student_SchoolMemberId = c.Int(),
                        CurrentTeacher_SchoolMemberId = c.Int(),
                    })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.Subjects", t => t.CurrentSubject_SubjectId)
                .ForeignKey("dbo.SchoolMembers", t => t.Student_SchoolMemberId)
                .ForeignKey("dbo.SchoolMembers", t => t.CurrentTeacher_SchoolMemberId)
                .Index(t => t.CurrentSubject_SubjectId)
                .Index(t => t.Student_SchoolMemberId)
                .Index(t => t.CurrentTeacher_SchoolMemberId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        CurrentTeacherFullName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.SchoolMembers",
                c => new
                    {
                        SchoolMemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        School = c.String(),
                        Avatar = c.Binary(),
                        Description = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Specialization = c.String(),
                        StudiesName = c.String(),
                        YearOfStudies = c.Int(),
                        StartStudiesDate = c.String(),
                        Degree = c.String(),
                        Room = c.String(),
                        TelephoneNumber = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.SchoolMemberId);
            
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
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CurrentType = c.Int(nullable: false),
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
                        CurrentMember_SchoolMemberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolMembers", t => t.CurrentMember_SchoolMemberId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.CurrentMember_SchoolMemberId);
            
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
                "dbo.SchoolMemberSubjects",
                c => new
                    {
                        SchoolMember_SchoolMemberId = c.Int(nullable: false),
                        Subject_SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SchoolMember_SchoolMemberId, t.Subject_SubjectId })
                .ForeignKey("dbo.SchoolMembers", t => t.SchoolMember_SchoolMemberId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId, cascadeDelete: true)
                .Index(t => t.SchoolMember_SchoolMemberId)
                .Index(t => t.Subject_SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CurrentMember_SchoolMemberId", "dbo.SchoolMembers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Grades", "CurrentTeacher_SchoolMemberId", "dbo.SchoolMembers");
            DropForeignKey("dbo.Grades", "Student_SchoolMemberId", "dbo.SchoolMembers");
            DropForeignKey("dbo.SchoolMemberSubjects", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SchoolMemberSubjects", "SchoolMember_SchoolMemberId", "dbo.SchoolMembers");
            DropForeignKey("dbo.Grades", "CurrentSubject_SubjectId", "dbo.Subjects");
            DropIndex("dbo.SchoolMemberSubjects", new[] { "Subject_SubjectId" });
            DropIndex("dbo.SchoolMemberSubjects", new[] { "SchoolMember_SchoolMemberId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "CurrentMember_SchoolMemberId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Grades", new[] { "CurrentTeacher_SchoolMemberId" });
            DropIndex("dbo.Grades", new[] { "Student_SchoolMemberId" });
            DropIndex("dbo.Grades", new[] { "CurrentSubject_SubjectId" });
            DropTable("dbo.SchoolMemberSubjects");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SchoolMembers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Grades");
        }
    }
}
