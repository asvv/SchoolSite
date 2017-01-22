namespace SchoolSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelMigration4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "Student_SchoolMemberId", "dbo.SchoolMembers");
            DropIndex("dbo.Subjects", new[] { "Student_SchoolMemberId" });
            CreateTable(
                "dbo.StudentSubjects",
                c => new
                    {
                        Student_SchoolMemberId = c.Int(nullable: false),
                        Subject_SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_SchoolMemberId, t.Subject_SubjectId })
                .ForeignKey("dbo.SchoolMembers", t => t.Student_SchoolMemberId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId, cascadeDelete: true)
                .Index(t => t.Student_SchoolMemberId)
                .Index(t => t.Subject_SubjectId);
            
            DropColumn("dbo.Subjects", "Student_SchoolMemberId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Student_SchoolMemberId", c => c.Int());
            DropForeignKey("dbo.StudentSubjects", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudentSubjects", "Student_SchoolMemberId", "dbo.SchoolMembers");
            DropIndex("dbo.StudentSubjects", new[] { "Subject_SubjectId" });
            DropIndex("dbo.StudentSubjects", new[] { "Student_SchoolMemberId" });
            DropTable("dbo.StudentSubjects");
            CreateIndex("dbo.Subjects", "Student_SchoolMemberId");
            AddForeignKey("dbo.Subjects", "Student_SchoolMemberId", "dbo.SchoolMembers", "SchoolMemberId");
        }
    }
}
