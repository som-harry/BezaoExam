namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDeadApplyForJob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyForJobs", "DateApply", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplyForJobs", "DateApply");
        }
    }
}
