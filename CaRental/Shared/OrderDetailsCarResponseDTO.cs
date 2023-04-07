using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaRental.Shared
{
    public class OrderDetailsCarResponseDTO
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Edition { get; set; }
        public string Image { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
