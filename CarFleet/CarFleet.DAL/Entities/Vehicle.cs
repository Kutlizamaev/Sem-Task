using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.DAL.Entities
{
    public class Vehicle
    {
        public string? Id { get; set; }
        public string? CategoryId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Horsepower { get; set; }
        public int NumberOfSeats { get; set; }
        public int Mileage { get; set; }

        public VehicleCategory? Category { get; set; } = null;
        public List<BookingOrder>? Bookings { get; set; } = new List<BookingOrder>();
        public List<VehicleReview>? Reviews { get; set; } = new List<VehicleReview>();
    }
}
