using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IoTSensorPortal.Data.Models
{
    public class Sensor

    {
        private ICollection<RegisteredUser> sharedWithUsers;
        private ICollection<History> history;

        public Sensor()
        {
            this.SharedTo = new HashSet<RegisteredUser>();
            this.History = new HashSet<History>();
        }

        public Guid Id { get; set; }

        [Required]
        public string OwnerId { get; set; }
        
        public bool IsPublic { get; set; }

        public DateTime LastUpdated { get; set; }

        public string CurrentValue { get; set; }

        public virtual RegisteredUser Owner { get; set; }
        public virtual ICollection<RegisteredUser> SharedTo { get; set; }
        public virtual ICollection<History> History
        {
            get
            {
                return this.history;
            }
            set
            {
                this.history = value;
            }
        }


    }
}
