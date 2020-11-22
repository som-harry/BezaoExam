namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeByteToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyForJobs", "ResumeLocation", c => c.String());
            DropColumn("dbo.ApplyForJobs", "Resume");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplyForJobs", "Resume", c => c.Binary());
            DropColumn("dbo.ApplyForJobs", "ResumeLocation");
        }
    }
}
