namespace IoTSensorPortal.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IoTSensorPortal.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IoTSensorPortal.Data.ApplicationDbContext context)
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
