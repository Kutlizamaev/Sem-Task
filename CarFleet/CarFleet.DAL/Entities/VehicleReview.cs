using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.DAL.Entities
{
    public class VehicleReview
    {
        public string? Id { get; set; }
        public string? Message { get; set; }
        public int Score { get; set; }
        public string? VehicleId { get; set;}
        public string? UserId { get; set; }

        public User? User { get; set; } = null;
        public Vehicle? Vehicle { get; set; } = null;
    }
}
