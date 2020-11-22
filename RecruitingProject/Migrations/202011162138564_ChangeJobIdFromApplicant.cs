namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeJobIdFromApplicant : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applicants", "JobId", "dbo.Jobs");
            DropIndex("dbo.Applicants", new[] { "JobId" });
            RenameColumn(table: "dbo.Applicants", name: "JobId", newName: "Job_Id");
            AddColumn("dbo.ApplyForJobs", "JobId", c => c.Int(nullable: false));
            AlterColumn("dbo.Applicants", "Job_Id", c => c.Int());
            CreateIndex("dbo.Applicants", "Job_Id");
            CreateIndex("dbo.ApplyForJobs", "JobId");
            AddForeignKey("dbo.ApplyForJobs", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Applicants", "Job_Id", "dbo.Jobs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applicants", "Job_Id", "dbo.Jobs");
            DropForeignKey("dbo.ApplyForJobs", "JobId", "dbo.Jobs");
            DropIndex("dbo.ApplyForJobs", new[] { "JobId" });
            DropIndex("dbo.Applicants", new[] { "Job_Id" });
            AlterColumn("dbo.Applicants", "Job_Id", c => c.Int(nullable: false));
            DropColumn("dbo.ApplyForJobs", "JobId");
            RenameColumn(table: "dbo.Applicants", name: "Job_Id", newName: "JobId");
            CreateIndex("dbo.Applicants", "JobId");
            AddForeignKey("dbo.Applicants", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
        }
    }
}
