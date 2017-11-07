using IoTSensorPortal.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace IoTSensorPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Sensor> Sensors { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
