namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTheCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories( CategoryName) VALUES ('UI designer')");
            Sql("INSERT INTO Categories( CategoryName) VALUES ('Marketer')");
            Sql("INSERT INTO Categories( CategoryName) VALUES ('Project Manager')");
            Sql("INSERT INTO Categories( CategoryName) VALUES ('Backend Developer')");
            Sql("INSERT INTO Categories( CategoryName) VALUES ('Frontend Developer')");
            Sql("INSERT INTO Categories( CategoryName) VALUES ('Senoir Hr')");
            Sql("INSERT INTO Categories( CategoryName) VALUES ('IT Personnel')");
        }
        
        public override void Down()
        {
        }
    }
}
