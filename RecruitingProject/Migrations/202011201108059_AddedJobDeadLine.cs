namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedJobDeadLine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "JobDeadLine", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "JobDeadLine");
        }
    }
}
