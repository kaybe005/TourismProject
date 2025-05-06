using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourismManagementSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }

        public int UserId { get; set; }
        public virtual User Tourist { get; set; }

        public int TravelPakage { get; set; }
        public virtual TravelPackage TravelPackage { get; set; }
    }
}