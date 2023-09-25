using CarFleet.DAL.Entities;
using CarFleet.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.DAL.Repositories
{
    public class VehicleRepository : IVehicleRepository<Vehicle>
    {
        private readonly DatabaseContext _databaseContext;

        public VehicleRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task Add(Vehicle vehicle)
        {
            await _databaseContext.AddAsync(vehicle);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Vehicle> GetById(string id)
        {
            return await _databaseContext.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<Vehicle>> GetAll()
        {
            return await _databaseContext.Vehicles.ToListAsync();
        }

        public async Task Update(Vehicle vehicle)
        {
            _databaseContext.Vehicles.Update(vehicle);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
