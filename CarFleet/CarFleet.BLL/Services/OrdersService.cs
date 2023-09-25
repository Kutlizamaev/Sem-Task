using CarFleet.BLL.DTO;
using CarFleet.DAL.Entities;
using CarFleet.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CarFleet.BLL.Services
{
    public class OrdersService
    {
        private readonly IOrdersRepository<BookingOrder> _ordersRepository;
        private readonly IVehicleRepository<Vehicle> _vehicleRepository;
        private readonly UserManager<User> _userManager;

        public OrdersService(
            IOrdersRepository<BookingOrder> ordersRepository,
            IVehicleRepository<Vehicle> vehicleRepository,
            UserManager<User> userManager)
        {
            _ordersRepository = ordersRepository;
            _vehicleRepository = vehicleRepository;
            _userManager = userManager;
        }

        public async Task<List<BookingOrderDTO>> GetOrdersByUserId(string id)
        {
            try
            {
                List<BookingOrder> orders = await _ordersRepository.GetOrdersByUserId(id);
                List<BookingOrderDTO> orderDtos = new List<BookingOrderDTO>();

                for (int i = 0; i < orders.Count(); i++)
                {
                    if (orders[i].IsClosed == false)
                    {
                        orderDtos.Add(new BookingOrderDTO()
                        {
                            Id = orders[i].Id,
                            PickupDate = orders[i].PickupDate,
                            PickupPlace = orders[i].PickupPlace,
                            DropoffDate = orders[i].DropoffDate,
                            DropoffPlace = orders[i].PickupPlace,

                            UserId = orders[i].UserId,
                            VehicleId = orders[i].VehicleId
                        });
                    }
                }

                return await Task.FromResult(orderDtos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + $"[{nameof(OrdersService)}:{nameof(GetOrdersByUserId)}]");
            }
        }

        public async Task<string> Book(BookingOrderDTO dto)
        {
            try
            {
                User user = await _userManager.FindByIdAsync(dto.UserId);
                Vehicle vehicle = await _vehicleRepository.GetById(dto.VehicleId);

                BookingOrder order = new BookingOrder()
                {
                    Id = Guid.NewGuid().ToString(),
                    PickupDate = dto.PickupDate,
                    PickupPlace = dto.PickupPlace,
                    DropoffDate = dto.DropoffDate,
                    DropoffPlace = dto.PickupPlace,
                    IsClosed = false,
                    UserId = dto.UserId,
                    VehicleId = dto.VehicleId,

                    User = user,
                    Vehicle = vehicle,
                };

                await _ordersRepository.Add(order);
                return order.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + $"[{nameof(OrdersService)}:{nameof(Book)}]");
            }
        }

        public async Task CloseOrder(string id)
        {
            try
            {
                await _ordersRepository.CloseOrder(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + $"[{nameof(OrdersService)}:{nameof(CloseOrder)}]");
            }
        }
    }
}
