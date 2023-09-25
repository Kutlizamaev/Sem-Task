using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.DAL.Entities
{
    public class VehicleCategory
    {
        public string? Id { get; set; }
        public string? Name { get; set; }

        public List<Vehicle>? Vehicles { get; set; } = new List<Vehicle>();
    }
}
