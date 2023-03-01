using CaRental.Shared;
using Microsoft.EntityFrameworkCore;

namespace CaRental.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Edition> Editions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Exclusives", Url = "exclusive", Icon = "plus" },
                new Category { Id = 2, Name = "Sports", Url = "sport", Icon = "plus" },
                new Category { Id = 3, Name = "Oldschool", Url = "oldschool", Icon = "plus" }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    CategoryId = 1,
                    Brand = "Maybach",
                    Description = "W223",
                    Image = "https://www.premiumfelgi.pl/userdata/gfx/57200.jpg",
                    Price = 900,
                    OrginalPrice = 1000,
                    DateCreated= new DateTime(2023,02,21)
                },
                new Car
                {
                    Id = 2,
                    CategoryId = 2,
                    Brand = "Mercedes",
                    Description = "AMG GT 63 S E 4-door",
                    Image = "https://motofilm.pl/wp-content/uploads/2022/02/Mercedes-AMG-GT-63-S-E-Performance-4-Drzwiowe-Coupe-1.jpg",
                    Price = 700,
                    OrginalPrice = 800,
                    DateCreated = new DateTime(2023, 02, 21)
                },
                new Car
                {
                    Id = 3,
                    CategoryId = 3,
                    Brand = "Mercedes",
                    Description = "SL500",
                    Image = "https://images8.alphacoders.com/114/1142237.jpg",
                    Price = 1000,
                    OrginalPrice = 1100,
                    DateCreated = new DateTime(2023, 02, 21)
                }
            );

            modelBuilder.Entity<Edition>().HasData(
                    new Edition { Id = 1, Name = "1 day" },
                  //new Edition { Id = 2, Name = "2 day" },
                    new Edition { Id = 3, Name = "3 day" },
                  //new Edition { Id = 4, Name = "4 day" },
                    new Edition { Id = 5, Name = "5 day" }
                );

            modelBuilder.SharedTypeEntity<Dictionary<string, object>>("CarEdition")
                .HasData(
                    new { EditionsId = 1, CarsId = 1 },
                    new { EditionsId = 3, CarsId = 1 },
                    new { EditionsId = 5, CarsId = 1 },
                    new { EditionsId = 1, CarsId = 2 },
                    new { EditionsId = 3, CarsId = 2 },
                    new { EditionsId = 5, CarsId = 2 },
                    new { EditionsId = 1, CarsId = 3 },
                    new { EditionsId = 3, CarsId = 3 },
                    new { EditionsId = 5, CarsId = 3 }
                );
        }

    }
}
