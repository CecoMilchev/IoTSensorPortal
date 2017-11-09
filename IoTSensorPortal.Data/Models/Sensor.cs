using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IoTSensorPortal.Data.Models
{
    public class Sensor

    {
        private ICollection<RegisteredUser> sharedWith;
        private ICollection<History> history;

        public Sensor()
        {
            this.SharedWith = new HashSet<RegisteredUser>();
            this.History = new HashSet<History>();
        }

        public Guid Id { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public bool IsPublic { get; set; }

        public DateTime LastUpdated { get; set; }

        public string CurrentValue { get; set; }

        public virtual RegisteredUser Owner { get; set; }
        public virtual ICollection<RegisteredUser> SharedWith { get; set; }
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
