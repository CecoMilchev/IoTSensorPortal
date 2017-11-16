using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IoTSensorPortal.Data.Models
{
    public class Sensor
    {
        public Sensor()
        {
            this.SharedWithUsers = new HashSet<RegisteredUser>();
            this.History = new HashSet<History>();
        }

        public Guid Id { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual RegisteredUser Owner { get; set; }

        public string Url { get; set; }
        public string Name { get; set; }
        public int RefreshRate { get; set; }

        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public bool IsPublic { get; set; }

        public string CurrentValue { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual ICollection<RegisteredUser> SharedWithUsers { get; set; }

        public virtual ICollection<History> History { get; set; }
    }
}
