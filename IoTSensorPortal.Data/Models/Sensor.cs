using Bytes2you.Validation;
using IoTSensorPortal.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSensorPortal.Data.Models
{
    public class Sensor
    {
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

        public string Description { get; set; }

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

    }
}
