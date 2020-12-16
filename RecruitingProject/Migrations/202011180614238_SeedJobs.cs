namespace RecruitingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedJobs : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Jobs( JobName, ImageLocation, Amount,JobDescription,EmployerName, AboutEmployer,MobileNumber,Email, OfficeLine, Website ) VALUES ('IT Personnel','https://res.cloudinary.com/sommy/image/upload/v1605563535/dvrqr9aoz6wfbo3r5dgm.jpg', 3000, 'Until recently, the prevailing view assumed lorem ipsum was born as a nonsense text. “It's not Latin, though it looks like it, and it actually says nothing,” Before & After magazine answered a curious reader, “Its ‘words’ loosely approximate the frequency with which letters occur in English, which is why at a glance it looks pretty real.”The placeholder text, beginning with the line “Lorem ipsum dolor sit amet, consectetur adipiscing elit”, looks like Latin because in its youth, centuries ago, it was Latin.', 'Richard McClintock', 'Richard McClintock, a Latin scholar from Hampden-Sydney College, is credited with discovering the source behind the ubiquitous filler text. In seeing a sample of lorem ipsum, his interest was piqued by consectetur—a genuine, albeit rare, Latin word. Consulting a Latin dictionary led McClintock to a passage from De Finibus Bonorum et Malorum ', 09023141625,'Mark@gmail.com', '+234 543 123', 'www.mark.com') ");
            Sql("INSERT INTO Jobs( JobName, ImageLocation, Amount,JobDescription,EmployerName, AboutEmployer,MobileNumber,Email, OfficeLine, Website ) VALUES ('Project Manager','https://res.cloudinary.com/sommy/image/upload/v1605563535/dvrqr9aoz6wfbo3r5dgm.jpg', 3000, 'Until recently, the prevailing view assumed lorem ipsum was born as a nonsense text. “It's not Latin, though it looks like it, and it actually says nothing,” Before & After magazine answered a curious reader, “Its ‘words’ loosely approximate the frequency with which letters occur in English, which is why at a glance it looks pretty real.”The placeholder text, beginning with the line “Lorem ipsum dolor sit amet, consectetur adipiscing elit”, looks like Latin because in its youth, centuries ago, it was Latin.', 'Richard McClintock', 'Richard McClintock, a Latin scholar from Hampden-Sydney College, is credited with discovering the source behind the ubiquitous filler text. In seeing a sample of lorem ipsum, his interest was piqued by consectetur—a genuine, albeit rare, Latin word. Consulting a Latin dictionary led McClintock to a passage from De Finibus Bonorum et Malorum ', 09023141625,'Mark@gmail.com', '+234 543 123', 'www.mark.com') ");
            Sql("INSERT INTO Jobs( JobName, ImageLocation, Amount,JobDescription,EmployerName, AboutEmployer,MobileNumber,Email, OfficeLine, Website ) VALUES ('UI Designer','https://res.cloudinary.com/sommy/image/upload/v1605563535/dvrqr9aoz6wfbo3r5dgm.jpg', 3000, 'Until recently, the prevailing view assumed lorem ipsum was born as a nonsense text. “It's not Latin, though it looks like it, and it actually says nothing,” Before & After magazine answered a curious reader, “Its ‘words’ loosely approximate the frequency with which letters occur in English, which is why at a glance it looks pretty real.”The placeholder text, beginning with the line “Lorem ipsum dolor sit amet, consectetur adipiscing elit”, looks like Latin because in its youth, centuries ago, it was Latin.', 'Richard McClintock', 'Richard McClintock, a Latin scholar from Hampden-Sydney College, is credited with discovering the source behind the ubiquitous filler text. In seeing a sample of lorem ipsum, his interest was piqued by consectetur—a genuine, albeit rare, Latin word. Consulting a Latin dictionary led McClintock to a passage from De Finibus Bonorum et Malorum ', 09023141625,'Mark@gmail.com', '+234 543 123', 'www.mark.com') ");
            
        }
        
        public override void Down()
        {
        }
    }
}
