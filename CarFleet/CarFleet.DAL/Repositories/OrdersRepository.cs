using CarFleet.DAL.Entities;
using CarFleet.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarFleet.DAL.Repositories
{
    public class OrdersRepository : IOrdersRepository<BookingOrder>
    {
        private readonly DatabaseContext _databaseContext;

        public OrdersRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task Add(BookingOrder order)
        {
            await _databaseContext.AddAsync(order);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task<BookingOrder> GetById(string id)
        {
            return await _databaseContext.Orders.FirstOrDefaultAsync(o => o.UserId == id);
        }

        public async Task<List<BookingOrder>> GetOrdersByUserId(string id)
        {
            return await _databaseContext.Orders.Where(o => o.UserId.Contains(id)).ToListAsync();
        }

        public async Task<List<BookingOrder>> GetAll()
        {
            return await _databaseContext.Orders.ToListAsync();
        }

        public async Task Update(BookingOrder order)
        {
            _databaseContext.Orders.Update(order);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task CloseOrder(string id)
        {
            BookingOrder order = await _databaseContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            order.IsClosed = true;
            _databaseContext.Update(order);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
