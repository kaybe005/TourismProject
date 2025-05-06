using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourismManagementSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual AgencyProfile AgencyProfile { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Feedback> Feedbacks  { get; set; }
    }
}