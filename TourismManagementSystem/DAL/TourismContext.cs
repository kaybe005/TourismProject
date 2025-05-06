using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TourismManagementSystem.Models;

namespace TourismManagementSystem.DAL
{
    public class TourismContext : DbContext
    {
        public TourismContext() : base("TourismConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<AgencyProfile> AgencyProfiles { get; set; }
        public DbSet<TravelPackage> TravelPackages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>()
                .HasRequired(f => f.TravelPackage)
                .WithMany(p => p.Feedbacks)
                .HasForeignKey(f => f.TravelPackageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedback>()
                .HasRequired(f => f.Tourist)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.UserId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}