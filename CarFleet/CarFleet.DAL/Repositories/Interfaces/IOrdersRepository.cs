using CarFleet.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.DAL.Repositories.Interfaces
{
    public interface IOrdersRepository<TEntity> : IRepository<BookingOrder>
    {
        public Task<List<BookingOrder>> GetOrdersByUserId(string id);
        public Task CloseOrder(string id);
    }
}
