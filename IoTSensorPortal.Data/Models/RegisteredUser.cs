using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IoTSensorPortal.Data.Models
{
    public class RegisteredUser : IdentityUser
    {
        public RegisteredUser()
        {
            this.OwnSensors = new HashSet<Sensor>();
            this.SharedSensors = new HashSet<Sensor>();
        }

        public virtual ICollection<Sensor> OwnSensors { get; set; }

        public virtual ICollection<Sensor> SharedSensors { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<RegisteredUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
