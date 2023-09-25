using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.BLL.DTO
{
    public class BookingOrderDTO
    {
        public string? Id { get; set; }
        public DateTime PickupDate { get; set; }
        public string? PickupPlace { get; set; }
        public DateTime DropoffDate { get; set; }
        public string? DropoffPlace { get; set; }

        public string? UserId { get; set; }
        public string? VehicleId { get; set; }
    }
}
