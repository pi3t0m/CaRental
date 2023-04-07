using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaRental.Shared
{
    public class OrderItem
    {
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
        public Edition Edition { get; set; }
        public int EditionId { get; set; }

        [Column(TypeName = "Decimal(18,2)")]
        public decimal TotalPrice { get; set; }
    }
}
