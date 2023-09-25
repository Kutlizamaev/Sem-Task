using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.BLL.Responses
{
    public class AddVehicleResponse
    {
        public string? CategoryId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Description { get; set; }
        public FileStream? File { get; set; }
        public int Price { get; set; }
        public int Horsepower { get; set; }
        public int NumberOfSeats { get; set; }
        public int Mileage { get; set; }
    }
}
