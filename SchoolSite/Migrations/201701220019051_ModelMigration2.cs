namespace SchoolSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CurrentType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CurrentType");
        }
    }
}
