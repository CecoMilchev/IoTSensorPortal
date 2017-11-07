
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System.Linq;

namespace IoTSensorPortal.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                var role = context.Roles.Add(new IdentityRole("Admin"));
                context.SaveChanges();

                role = context.Roles.Single();
                var user = context.Users.Single();
                user.Roles.Add(new IdentityUserRole()
                {
                    RoleId = role.Id,
                    UserId = user.Id
                });

                context.SaveChanges();
            }
        }
    }
}
