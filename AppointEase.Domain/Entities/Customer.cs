using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointEase.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Email { get; set; }

        [MaxLength(11)]
        public string? MobileNumber { get; set; }

        [MaxLength(500)]
        public string Password { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
