using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaRental.Shared
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Image { get; set; } = "https://via.placeholder.com/300x300";
        public bool IsPublic { get; set; }
        public bool IsDeleted { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<CarVariant> Variants { get; set; } = new List<CarVariant>();
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }
        public int Views { get; set; }


    }
}
