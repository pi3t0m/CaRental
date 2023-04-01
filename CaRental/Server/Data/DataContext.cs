using System;
using CaRental.Shared;
using Microsoft.EntityFrameworkCore;

namespace CaRental.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // ... inne opcje konfiguracji
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarVariant>()
                .HasKey(c => new { c.CarId, c.EditionId });

            modelBuilder.Entity<Edition>().HasData(
                new Edition { Id = 1, Name = "Default" },
                new Edition { Id = 2, Name = "1 day" },
              //new Edition { Id = 3, Name = "2 day" },
                new Edition { Id = 4, Name = "3 day" },
              //new Edition { Id = 5, Name = "4 day" },
                new Edition { Id = 6, Name = "5 day" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category 
                { 
                    Id = 1,
                    Name = "Exclusives",
                    Url = "exclusive",
                    Icon = "plus" 
                },
                new Category 
                { 
                    Id = 2,
                    Name = "Sports",
                    Url = "sport",
                    Icon = "plus" 
                },
                new Category 
                { 
                    Id = 3,
                    Name = "Oldschool",
                    Url = "oldschool",
                    Icon = "plus"
                }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    CategoryId = 1,
                    Brand = "Maybach",
                    Description = "W223",
                    Image = "https://www.premiumfelgi.pl/userdata/gfx/57200.jpg",
                    DateCreated = new DateTime(2023, 02, 21),
                    Featured = true
                },
                new Car
                {
                    Id = 2,
                    CategoryId = 2,
                    Brand = "Mercedes",
                    Description = "AMG GT 63 S E 4-door",
                    Image = "https://motofilm.pl/wp-content/uploads/2022/02/Mercedes-AMG-GT-63-S-E-Performance-4-Drzwiowe-Coupe-1.jpg",
                    DateCreated = new DateTime(2023, 02, 21)
                },
                new Car
                {
                    Id = 3,
                    CategoryId = 3,
                    Brand = "Mercedes",
                    Description = "SL500",
                    Image = "https://images8.alphacoders.com/114/1142237.jpg",
                    DateCreated = new DateTime(2023, 02, 21),
                    Featured = true
                }
            ); 

            modelBuilder.Entity<CarVariant>().HasData(
                new CarVariant
                {
                    CarId = 1,
                    EditionId = 2,
                    Price = 900.00m,
                    OrginalPrice = 1000.00m
                },
                new CarVariant
                {
                    CarId = 1,
                    EditionId = 4,
                    Price = 2500.00m,
                    OrginalPrice = 3000.00m
                },
                new CarVariant
                {
                    CarId = 1,
                    EditionId = 6,
                    Price = 4000.00m,
                    OrginalPrice = 5000.00m
                },
                new CarVariant
                {
                    CarId = 2,
                    EditionId = 2,
                    Price = 900.00m,
                    OrginalPrice = 1000.00m
                },
                new CarVariant
                {
                    CarId = 2,
                    EditionId = 4,
                    Price = 2500.00m,
                    OrginalPrice = 3000.00m
                },
                new CarVariant
                {
                    CarId = 2,
                    EditionId = 6,
                    Price = 4000.00m,
                    OrginalPrice = 5000.00m
                },
                new CarVariant
                {
                    CarId = 3,
                    EditionId = 2,
                    Price = 900.00m,
                    OrginalPrice = 1000.00m
                },
                new CarVariant
                {
                    CarId = 3,
                    EditionId = 4,
                    Price = 2500.00m,
                    OrginalPrice = 3000.00m
                },
                new CarVariant
                {
                    CarId = 3,
                    EditionId = 6,
                    Price = 4000.00m,
                    OrginalPrice = 5000.00m
                }
                );
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<CarVariant> CarVariants { get; set; }
        public DbSet<Stats> Stats { get; set; }

    }
}
