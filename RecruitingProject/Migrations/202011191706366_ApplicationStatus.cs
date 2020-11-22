namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicants", "ApplicationStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applicants", "ApplicationStatus", c => c.Boolean(nullable: false));
        }
    }
}
