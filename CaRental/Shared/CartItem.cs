using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaRental.Shared
{
    public class CartItem
    {
        public int CarId { get; set; }
        public int EditionId { get; set; }
        public string CarTitle { get; set; }
        public string EditionName { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

    }
}
