namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedToJobEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "JobDescription", c => c.String());
            AddColumn("dbo.Jobs", "EmployerName", c => c.String());
            AddColumn("dbo.Jobs", "AboutEmployer", c => c.String());
            AddColumn("dbo.Jobs", "MobileNumber", c => c.String());
            AddColumn("dbo.Jobs", "Email", c => c.String());
            AddColumn("dbo.Jobs", "OfficeLine", c => c.String());
            AddColumn("dbo.Jobs", "Website", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Website");
            DropColumn("dbo.Jobs", "OfficeLine");
            DropColumn("dbo.Jobs", "Email");
            DropColumn("dbo.Jobs", "MobileNumber");
            DropColumn("dbo.Jobs", "AboutEmployer");
            DropColumn("dbo.Jobs", "EmployerName");
            DropColumn("dbo.Jobs", "JobDescription");
        }
    }
}
