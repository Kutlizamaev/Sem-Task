using CarFleet.DAL.Configuration;
using CarFleet.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarFleet.DAL
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<BookingOrder> Orders { get; set; }
        public DbSet<CompanyReview> CompanyReviews { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }
        public DbSet<VehicleReview> VehicleReviews { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelBuilderConfiguration.Configure(builder);
        }
    }
}
