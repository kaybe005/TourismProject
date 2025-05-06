using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Web;

namespace TourismManagementSystem.Models
{
    public class TravelPackage
    {
        public int TravelPackageId { get; set; }
        public string Title { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxGroupSize { get; set; }

        public int UserId { get; set; }
        public virtual User Agency { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}

