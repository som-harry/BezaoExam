namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedYourGreatestAchievement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyForJobs", "WhatYourgreatestAchieviement", c => c.String());
            DropColumn("dbo.ApplyForJobs", "WhatMakeYouSuitablefortheJob");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplyForJobs", "WhatMakeYouSuitablefortheJob", c => c.String());
            DropColumn("dbo.ApplyForJobs", "WhatYourgreatestAchieviement");
        }
    }
}
