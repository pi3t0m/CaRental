using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CaRental.Shared
{
    public class CarVariant
    {
        [JsonIgnore]
        public Car Car { get; set; }
        public int CarId { get; set; }
        public Edition Edition { get; set; }
        public int EditionId { get; set; }
        [Column(TypeName = "Decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "Decimal(18,2)")]
        public decimal OrginalPrice { get; set; }
    }
}
