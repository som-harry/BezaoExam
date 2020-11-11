namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedResumeToDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Applicants", "Resume", c => c.Binary());
            CreateIndex("dbo.Applicants", "UserId");
            AddForeignKey("dbo.Applicants", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applicants", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Applicants", new[] { "UserId" });
            DropColumn("dbo.Applicants", "Resume");
            DropColumn("dbo.Applicants", "UserId");
        }
    }
}
