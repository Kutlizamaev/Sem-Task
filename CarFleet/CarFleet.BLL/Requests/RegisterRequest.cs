using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.BLL.Requests
{
    public class RegisterRequest
    {
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
