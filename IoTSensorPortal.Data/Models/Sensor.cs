using System;
using System.Collections.Generic;

namespace IoTSensorPortal.Data.Models
{
    public class Sensor : I
    {
<<<<<<< HEAD
        //fields 
        public Sensor()
        {
         //init    
        }


        public Guid Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
=======
        private ICollection<ApplicationUser> sharedWithUsers;
        private ICollection<History> history;

        public Sensor()
        {
            this.SharedWithUsers = new HashSet<ApplicationUser>();
            this.History = new HashSet<History>();
        }

        public Guid Id { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

>>>>>>> 80ed9acb03256809300c40694b0153580778031a
        public string Description { get; set; }
        public string Url { get; set; }
        public int RefreshRate { get; set; }
        public Measure Unit { get; set; }
        public string UnitRange { get; set; } // string min-max to reduce complexity

<<<<<<< HEAD
        public Access Access { get; set; }

        public virtual ICollection<RegisteredUser> SharedWith { get; set; }
        public virtual RegisteredUser Owner { get; set; }
        public virtual IDictionary<DateTime, int> MeasuredValues { get; set; } // history datetime is UTC
=======
        public string Tag { get; set; }

        public string MeasureType { get; set; }

        public int MinPollingIntervalInSeconds { get; set; }

        public bool IsPublic { get; set; }

        public DateTime LastUpdated { get; set; }

        public string CurrentValue { get; set; }

        public virtual ICollection<ApplicationUser> SharedWithUsers
        {
            get
            {
                return this.sharedWithUsers;
            }
            set
            {
                this.sharedWithUsers = value;
            }
        }

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

>>>>>>> 80ed9acb03256809300c40694b0153580778031a
    }
}
