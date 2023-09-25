using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(string id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
    }
}
