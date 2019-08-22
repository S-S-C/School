namespace School.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using School.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<School.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(School.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
             new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            var userManager = new UserManager<ApplicationUser>(
           new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "daisy.blue19@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "daisy.blue19@gmail.com",
                    Email = "daisy.blue19@gmail.com",
                    FirstName = "Daisy",
                    LastName = "Blue",
                    DisplayName = "DB"
                }, "Coding19!");
            }

            var userId = userManager.FindByEmail("daisy.blue19@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");

            //Create moderator role
            var roleModerator = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleModerator.Create(new IdentityRole { Name = "Moderator" });
            }

            var userModerator = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "araynor@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "araynor@coderfoundry.com",
                    Email = "araynor@coderfoundry.com",
                    FirstName = "A",
                    LastName = "R",
                    DisplayName = "AR"
                }, "Mposts!");
            }

            var userId2 = userManager.FindByEmail("araynor@coderfoundry.com").Id;
            userManager.AddToRole(userId2, "Moderator");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
