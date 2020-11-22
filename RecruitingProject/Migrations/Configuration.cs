namespace RecruitingProject.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RecruitingProject.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RecruitingProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RecruitingProject.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var UserStore = new UserStore<ApplicationUser>(context);
            var UserManager = new UserManager<ApplicationUser>(UserStore);
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var rolemanager = new RoleManager<IdentityRole>(roleStore);

            ApplicationUser User = new ApplicationUser()
            {
                Email = "Admin@gmail.com",
                UserName = "Admin@gmail.com",
                EmailConfirmed = true
            };
            IdentityResult result = UserManager.Create(User, "Admin@gmail.com");
            if (result.Succeeded)
            {
                if (!rolemanager.RoleExists("ADMIN"))
                {
                    var role = new IdentityRole();
                    role.Name = "ADMIN";
                    rolemanager.Create(role);
                    UserManager.AddToRole(User.Id, "ADMIN");

                }
                UserManager.AddToRole(User.Id, "ADMIN");
            }
        }
    }
}
