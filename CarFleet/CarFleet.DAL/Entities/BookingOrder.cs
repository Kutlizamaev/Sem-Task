using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.DAL.Entities
{
    public class BookingOrder
    {
        public string? Id { get; set; }
        public DateTime PickupDate { get; set; }
        public string? PickupPlace { get; set; }
        public DateTime DropoffDate { get; set; }
        public string? DropoffPlace { get; set; }
        public bool IsClosed { get; set; }
        public string? UserId { get; set; }
        public string? VehicleId { get; set; }

        public User? User { get; set; } = null;
        public Vehicle? Vehicle { get; set; } = null;
    }
}
