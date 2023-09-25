using CarFleet.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarFleet.DAL.Configuration
{
    public static class ModelBuilderConfiguration
    {
        public static ModelBuilder Configure(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
                entity.Ignore(u => u.AccessFailedCount);
                entity.Ignore(u => u.PhoneNumber);
                entity.Ignore(u => u.PhoneNumberConfirmed);
                entity.Ignore(u => u.TwoFactorEnabled);
                entity.Ignore(u => u.LockoutEnabled);
                entity.Ignore(u => u.LockoutEnd);
                entity.Ignore(u => u.ConcurrencyStamp);
                entity.Ignore(u => u.SecurityStamp);
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Ignore<IdentityUserToken<string>>();

            builder.Entity<User>()
                .HasMany(e => e.CompanyReviews)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);

            builder.Entity<User>()
                .HasMany(e => e.VehicleReviews)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);

            builder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);

            builder.Entity<Vehicle>()
                .HasMany(e => e.Bookings)
                .WithOne(e => e.Vehicle)
                .HasForeignKey(e => e.VehicleId)
                .IsRequired(false);

            builder.Entity<Vehicle>()
                .HasOne(e => e.Category)
                .WithMany(e => e.Vehicles)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired();

            builder.Entity<Vehicle>()
                .HasMany(e => e.Reviews)
                .WithOne(e => e.Vehicle)
                .HasForeignKey(e => e.VehicleId)
                .IsRequired(false);

            builder.Entity<VehicleCategory>()
                .HasMany(e => e.Vehicles)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired(false);

            builder.Entity<BookingOrder>()
                .HasOne(e => e.User)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            builder.Entity<BookingOrder>()
                .HasOne(e => e.Vehicle)
                .WithMany(e => e.Bookings)
                .HasForeignKey(e => e.VehicleId)
                .IsRequired();

            builder.Entity<CompanyReview>()
                .HasOne(e => e.User)
                .WithMany(e => e.CompanyReviews)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            builder.Entity<VehicleReview>()
                .HasOne(e => e.User)
                .WithMany(e => e.VehicleReviews)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            builder.Entity<VehicleReview>()
                .HasOne(e => e.Vehicle)
                .WithMany(e => e.Reviews)
                .HasForeignKey(e => e.VehicleId)
                .IsRequired();

            builder.Entity<VehicleCategory>()
                .HasData(
                    new VehicleCategory
                    {
                        Id = "0",
                        Name = "Econom"
                    },
                    new VehicleCategory
                    {
                        Id = "1",
                        Name = "Comfort",
                    },
                    new VehicleCategory
                    {
                        Id = "2",
                        Name = "Premium",
                    },
                    new VehicleCategory
                    {
                        Id = "3",
                        Name = "Luxury",
                    }
                );
            builder.Entity<Vehicle>()
                .HasData(
                new Vehicle
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryId = "0",
                    Brand = "Hyundai",
                    Model = "Solaris",
                    Description = "Hyundai Solaris — субкомпактный автомобиль южнокорейской компании Hyundai Motors. Автомобиль представляет собой локализованную версию автомобиля Hyundai Accent, адаптированную для эксплуатации в российских условиях.",
                    Price = 10,
                    Horsepower = 100,
                    NumberOfSeats = 5,
                    Mileage = 300,
                },
                new Vehicle
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryId = "1",
                    Brand = "Kia",
                    Model = "K5",
                    Description = "Kia K5 (также известен как Kia Optima или Kia Magentis) — седан среднего класса южнокорейской автомобилестроительной компании Kia Motors, производство которого было начато в 2000-м году. ",
                    Price = 15,
                    Horsepower = 290,
                    NumberOfSeats = 5,
                    Mileage = 230,
                },
                new Vehicle
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryId = "2",
                    Brand = "Mercedes-Benz",
                    Model = "E63",
                    Description = "Четырехдверный седан E63 AMG сочетает в себе великолепные ходовые качества и высочайщий комфорт.",
                    Price = 35,
                    Horsepower = 520,
                    NumberOfSeats = 5,
                    Mileage = 180,
                },
                new Vehicle
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryId = "3",
                    Brand = "Tesla",
                    Model = "Model X",
                    Description = "Tesla Model X — полноразмерный электрический кроссовер производства компании Tesla.",
                    Price = 50,
                    Horsepower = 800,
                    NumberOfSeats = 5,
                    Mileage = 50,
                },
                new Vehicle
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryId = "2",
                    Brand = "Kia",
                    Model = "Stinger",
                    Description = "Kia Stinger — это бескомпромиссный автомобиль для водителя. Здесь все сделано специально для вас, от сидений со спортивной поддержкой до современных технологий. Вы сможете совершать самые продолжительные поездки, не чувствуя усталости.",
                    Price = 30,
                    Horsepower = 300,
                    NumberOfSeats = 5,
                    Mileage = 80,
                },
                new Vehicle
                {
                    Id = Guid.NewGuid().ToString(),
                    Brand = "Mercedes-Benz",
                    Model = "G-Wagen",
                    CategoryId = "3",
                    Description = "В отличие от иных серий транспортных средств торговой марки Mercedes-Benz, автомобили G-класса сохраняют свой уникальный внешний вид независимо от модификации, будь то заводская или высокопроизводительная",
                    Price = 40,
                    Horsepower = 430,
                    NumberOfSeats = 5,
                    Mileage = 320,
                }
                ); ;
            return builder;
        }
    }
}
