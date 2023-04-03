using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaRental.Shared
{
    public class CartCarResponseDTO
    {
        public int CarId {  get; set; }
        public string Brand { get; set; } = string.Empty;
        public int EditionId { get; set; }
        public string Edition { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
