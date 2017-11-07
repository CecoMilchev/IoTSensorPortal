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
        public Sensor()
        {
            this.SharedWithUsers = new HashSet<ApplicationUser>();
            this.SensorHistories = new HashSet<SensorHistory>();
        }

        public Guid Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<ApplicationUser> SharedWithUsers { get; set; }

        public virtual ICollection<SensorHistory> SensorHistories { get; set; }

        public string Tag { get; set; }

        public string Description { get; set; }

        public int MinPollingIntervalInSeconds { get; set; }

        public string MeasureType { get; set; }
    }
}
