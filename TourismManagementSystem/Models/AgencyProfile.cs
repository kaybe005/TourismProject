using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismManagementSystem.Models
{
    public class AgencyProfile
    {
        public int AgencyProfileId { get; set; }
        public string AgencyName { get; set; }
        public string ServicesOffered { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}