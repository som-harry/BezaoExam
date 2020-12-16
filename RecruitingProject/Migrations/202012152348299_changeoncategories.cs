namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeoncategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Jobs", "CategoryId", c => c.Int());
            CreateIndex("dbo.Jobs", "CategoryId");
            AddForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "CategoryId" });
            DropColumn("dbo.Jobs", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
