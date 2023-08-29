using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaRental.Shared
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PaswordSalt { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public Address Address { get; set; }
        public string Role { get; set; } = "Customer";
    }
}
