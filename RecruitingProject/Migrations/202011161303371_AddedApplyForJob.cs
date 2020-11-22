namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedApplyForJob : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplyForJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Resume = c.Binary(),
                        JobRole = c.String(),
                        WhatMakeYouSuitablefortheJob = c.String(),
                        ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .Index(t => t.ApplicantId);
            
            AddColumn("dbo.Applicants", "JobId", c => c.Int(nullable: false));
            CreateIndex("dbo.Applicants", "JobId");
            AddForeignKey("dbo.Applicants", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
            DropColumn("dbo.Applicants", "JobRole");
            DropColumn("dbo.Applicants", "Resume");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applicants", "Resume", c => c.Binary());
            AddColumn("dbo.Applicants", "JobRole", c => c.String());
            DropForeignKey("dbo.ApplyForJobs", "ApplicantId", "dbo.Applicants");
            DropForeignKey("dbo.Applicants", "JobId", "dbo.Jobs");
            DropIndex("dbo.ApplyForJobs", new[] { "ApplicantId" });
            DropIndex("dbo.Applicants", new[] { "JobId" });
            DropColumn("dbo.Applicants", "JobId");
            DropTable("dbo.ApplyForJobs");
            DropTable("dbo.Jobs");
        }
    }
}
