namespace TourismManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalFix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgencyProfiles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        AgencyProfileId = c.Int(nullable: false),
                        AgencyName = c.String(),
                        ServicesOffered = c.String(),
                        Description = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        BookingDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        UserId = c.Int(nullable: false),
                        TravelPakage = c.Int(nullable: false),
                        TravelPackage_TravelPackageId = c.Int(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.TravelPackages", t => t.TravelPackage_TravelPackageId)
                .Index(t => t.UserId)
                .Index(t => t.TravelPackage_TravelPackageId);
            
            CreateTable(
                "dbo.TravelPackages",
                c => new
                    {
                        TravelPackageId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Destination = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        MaxGroupSize = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TravelPackageId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackId = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                        UserId = c.Int(nullable: false),
                        TravelPackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FeedbackId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.TravelPackages", t => t.TravelPackageId)
                .Index(t => t.UserId)
                .Index(t => t.TravelPackageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AgencyProfiles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "TravelPackageId", "dbo.TravelPackages");
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Bookings", "TravelPackage_TravelPackageId", "dbo.TravelPackages");
            DropForeignKey("dbo.TravelPackages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropIndex("dbo.Feedbacks", new[] { "TravelPackageId" });
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropIndex("dbo.TravelPackages", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "TravelPackage_TravelPackageId" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropIndex("dbo.AgencyProfiles", new[] { "UserId" });
            DropTable("dbo.Feedbacks");
            DropTable("dbo.TravelPackages");
            DropTable("dbo.Bookings");
            DropTable("dbo.Users");
            DropTable("dbo.AgencyProfiles");
        }
    }
}
