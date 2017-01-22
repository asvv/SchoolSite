namespace SchoolSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelMigration3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Grades", name: "Subject_SubjectId", newName: "CurrentSubject_SubjectId");
            RenameIndex(table: "dbo.Grades", name: "IX_Subject_SubjectId", newName: "IX_CurrentSubject_SubjectId");
            AddColumn("dbo.Grades", "CurrentTeacher_SchoolMemberId", c => c.Int());
            AddColumn("dbo.SchoolMembers", "Specialization", c => c.String());
            AddColumn("dbo.SchoolMembers", "StudiesName", c => c.String());
            AddColumn("dbo.SchoolMembers", "YearOfStudies", c => c.Int());
            AddColumn("dbo.SchoolMembers", "StartStudiesDate", c => c.String());
            CreateIndex("dbo.Grades", "CurrentTeacher_SchoolMemberId");
            AddForeignKey("dbo.Grades", "CurrentTeacher_SchoolMemberId", "dbo.SchoolMembers", "SchoolMemberId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "CurrentTeacher_SchoolMemberId", "dbo.SchoolMembers");
            DropIndex("dbo.Grades", new[] { "CurrentTeacher_SchoolMemberId" });
            DropColumn("dbo.SchoolMembers", "StartStudiesDate");
            DropColumn("dbo.SchoolMembers", "YearOfStudies");
            DropColumn("dbo.SchoolMembers", "StudiesName");
            DropColumn("dbo.SchoolMembers", "Specialization");
            DropColumn("dbo.Grades", "CurrentTeacher_SchoolMemberId");
            RenameIndex(table: "dbo.Grades", name: "IX_CurrentSubject_SubjectId", newName: "IX_Subject_SubjectId");
            RenameColumn(table: "dbo.Grades", name: "CurrentSubject_SubjectId", newName: "Subject_SubjectId");
        }
    }
}
