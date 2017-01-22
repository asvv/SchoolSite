namespace SchoolSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelMigration : DbMigration
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
                        Student_SchoolMemberId = c.Int(),
                        Subject_SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.SchoolMembers", t => t.Student_SchoolMemberId)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId)
                .Index(t => t.Student_SchoolMemberId)
                .Index(t => t.Subject_SubjectId);
            
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
                        Degree = c.String(),
                        Room = c.String(),
                        TelephoneNumber = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.SchoolMemberId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        CurrentTeacherFullName = c.String(),
                        Student_SchoolMemberId = c.Int(),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.SchoolMembers", t => t.Student_SchoolMemberId)
                .Index(t => t.Student_SchoolMemberId);
            
            CreateTable(
                "dbo.TeacherSubjects",
                c => new
                    {
                        Teacher_SchoolMemberId = c.Int(nullable: false),
                        Subject_SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_SchoolMemberId, t.Subject_SubjectId })
                .ForeignKey("dbo.SchoolMembers", t => t.Teacher_SchoolMemberId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId, cascadeDelete: true)
                .Index(t => t.Teacher_SchoolMemberId)
                .Index(t => t.Subject_SubjectId);
            
            AddColumn("dbo.AspNetUsers", "CurrentMember_SchoolMemberId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "CurrentMember_SchoolMemberId");
            AddForeignKey("dbo.AspNetUsers", "CurrentMember_SchoolMemberId", "dbo.SchoolMembers", "SchoolMemberId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CurrentMember_SchoolMemberId", "dbo.SchoolMembers");
            DropForeignKey("dbo.Subjects", "Student_SchoolMemberId", "dbo.SchoolMembers");
            DropForeignKey("dbo.TeacherSubjects", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.TeacherSubjects", "Teacher_SchoolMemberId", "dbo.SchoolMembers");
            DropForeignKey("dbo.Grades", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Grades", "Student_SchoolMemberId", "dbo.SchoolMembers");
            DropIndex("dbo.TeacherSubjects", new[] { "Subject_SubjectId" });
            DropIndex("dbo.TeacherSubjects", new[] { "Teacher_SchoolMemberId" });
            DropIndex("dbo.AspNetUsers", new[] { "CurrentMember_SchoolMemberId" });
            DropIndex("dbo.Subjects", new[] { "Student_SchoolMemberId" });
            DropIndex("dbo.Grades", new[] { "Subject_SubjectId" });
            DropIndex("dbo.Grades", new[] { "Student_SchoolMemberId" });
            DropColumn("dbo.AspNetUsers", "CurrentMember_SchoolMemberId");
            DropTable("dbo.TeacherSubjects");
            DropTable("dbo.Subjects");
            DropTable("dbo.SchoolMembers");
            DropTable("dbo.Grades");
        }
    }
}
