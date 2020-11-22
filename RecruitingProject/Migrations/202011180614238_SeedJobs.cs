namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedJobs : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Jobs( JobName, ImageLocation, Amount) VALUES ('IT Personnel','https://res.cloudinary.com/sommy/image/upload/v1605563535/dvrqr9aoz6wfbo3r5dgm.jpg', 3000) ");
            Sql("INSERT INTO Jobs( JobName, ImageLocation, Amount) VALUES ('Project Manager','https://res.cloudinary.com/sommy/image/upload/v1605563535/dvrqr9aoz6wfbo3r5dgm.jpg', 7000) ");
            Sql("INSERT INTO Jobs( JobName, ImageLocation, Amount) VALUES ('UI Designer','https://res.cloudinary.com/sommy/image/upload/v1605563535/dvrqr9aoz6wfbo3r5dgm.jpg', 5000) ");
            
        }
        
        public override void Down()
        {
        }
    }
}
