using IoTSensorPortal.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace IoTSensorPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext<RegisteredUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Sensor> Sensors { get; set; }
<<<<<<< HEAD
        
=======



>>>>>>> 80ed9acb03256809300c40694b0153580778031a
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RegisteredUser>()
            .HasMany(owner => owner.SharedSensors)
            .WithMany(sensor => sensor.SharedWith);
        }
    }
}
