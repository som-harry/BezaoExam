namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangethebytesavingofFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyForJobs", "UploadResume", c => c.String());
            DropColumn("dbo.ApplyForJobs", "Resume");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplyForJobs", "Resume", c => c.Binary());
            DropColumn("dbo.ApplyForJobs", "UploadResume");
        }
    }
}
