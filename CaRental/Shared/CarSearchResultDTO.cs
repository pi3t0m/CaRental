using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaRental.Shared
{
    public class CarSearchResultDTO
    {
        public List<Car> Cars { get; set; } = new List<Car>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
