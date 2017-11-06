using IoTSensorPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IoTSensorPortal.Areas.Admin.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public bool IsAdmin { get; set; }

        public static Expression<Func<ApplicationUser, UserViewModel>> Create
        {
            get
            {
                return u => new UserViewModel()
                {
                    Id = u.Id,
                    Username = u.UserName
                };
            }
        }
    }
}