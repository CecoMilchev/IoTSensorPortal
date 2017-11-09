using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace IoTSensorPortal.Data.Models
{
    public class RegisteredUser : IdentityUser
    {
        private ICollection<Sensor> ownSensors;
        private ICollection<Sensor> sharedSensors;

        public RegisteredUser()
        {
            this.ownSensors = new HashSet<Sensor>();
            this.sharedSensors = new HashSet<Sensor>();
        }

        public virtual ICollection<Sensor> OwnSensors
        {
            get
            {
                return this.ownSensors;
            }
            set
            {
                this.ownSensors = value;
            }
        }

        public virtual ICollection<Sensor> SharedSensors
        {
            get
            {
                return this.sharedSensors;
            }
            set
            {
                this.sharedSensors = value;
            }
        }

   //     public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<RegisteredUser> manager)
   //     {
   //         // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
   //         var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
   //         // Add custom user claims here
   //         return userIdentity;
   //     }
    }
}
