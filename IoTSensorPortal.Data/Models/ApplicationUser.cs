using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IoTSensorPortal.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Sensor> sensors;

        public ApplicationUser()
        {
            this.sensors = new HashSet<Sensor>();
        }

        public virtual ICollection<Sensor> Sensors
        {
            get
            {
                return this.sensors;
            }
            set
            {
                this.sensors = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
