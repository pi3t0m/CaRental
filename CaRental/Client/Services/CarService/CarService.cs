using CaRental.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaRental.Client.Services.CarService
{
    public class CarService : ICarService
    {
        public List<Car> Cars { get; set; } = new List<Car>();

        public void LoadCars()
        {
            Cars = new List<Car>
            {
                new Car
                {
                    Id = 1,
                    CategoryId = 1,
                    Brand = "Maybach",
                    Description = "W223",
                    Image = "https://www.premiumfelgi.pl/userdata/gfx/57200.jpg",
                    Price = 900,
                    OrginalPrice = 1000,
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
                },
            };
        }
    }
}
