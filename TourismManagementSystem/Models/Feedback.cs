using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismManagementSystem.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public int UserId { get; set; }
        public virtual User Tourist { get; set; }

        [ForeignKey("TravelPackage")]
        public int TravelPackageId { get; set; }
        public virtual TravelPackage TravelPackage { get; set; }
    }
}