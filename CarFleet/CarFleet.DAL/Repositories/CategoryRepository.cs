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
    public class CategoryRepository : ICategoryRepository<VehicleCategory>
    {
        private readonly DatabaseContext _databaseContext;

        public CategoryRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task Add(VehicleCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleCategory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<VehicleCategory> GetById(string id)
        {
            return await _databaseContext.VehicleCategories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task Update(VehicleCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
