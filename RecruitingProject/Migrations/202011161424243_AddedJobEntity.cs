namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedJobEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "ImageLocation", c => c.String());
            AddColumn("dbo.Jobs", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Amount");
            DropColumn("dbo.Jobs", "ImageLocation");
        }
    }
}
