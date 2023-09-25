using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.DAL.Entities
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public DateTime BirthDate { get; set; }

        public List<CompanyReview>? CompanyReviews { get; set; } = new List<CompanyReview>();
        public List<VehicleReview>? VehicleReviews { get; set; } = new List<VehicleReview>();
        public List<BookingOrder>? Orders { get; set; } = new List<BookingOrder>();
    }
}
