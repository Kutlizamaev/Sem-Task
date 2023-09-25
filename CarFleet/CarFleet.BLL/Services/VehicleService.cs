using CarFleet.BLL.DTO;
using CarFleet.BLL.Responses;
using CarFleet.DAL.Entities;
using CarFleet.DAL.Repositories;
using CarFleet.DAL.Repositories.Interfaces;

namespace CarFleet.BLL.Services
{
    public class VehicleService
    {
        private readonly IVehicleRepository<Vehicle> _vehicleRepository;
        private readonly ICategoryRepository<VehicleCategory> _categoryRepository;
        private readonly FirebaseService _firebaseService;

        public VehicleService(IVehicleRepository<Vehicle> vehicleRepository, ICategoryRepository<VehicleCategory> categoryRepository, FirebaseService firebaseService)
        {
            _vehicleRepository = vehicleRepository;
            _categoryRepository = categoryRepository;
            _firebaseService = firebaseService;
        }

        public async Task Add(AddVehicleResponse response)
        {
            try
            {
                Vehicle vehicle = new Vehicle()
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryId = response.CategoryId,
                    Brand = response.Brand,
                    Model = response.Model,
                    Description = response.Description,
                    Price = response.Price,
                    Horsepower = response.Horsepower,
                    NumberOfSeats = response.NumberOfSeats,
                    Mileage = response.Mileage,
                };

                await _firebaseService.UploadFile(response.File, vehicle.Id);

                await _vehicleRepository.Add(vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + $"[{nameof(VehicleService)}:{nameof(Add)}]");
            }
        }

        public async Task<List<VehicleDTO>> GetVehicles()
        {
            try
            {
                List<Vehicle> vehicles = await _vehicleRepository.GetAll();
                List<VehicleDTO> vehicledtos = new List<VehicleDTO>();
                for (int i = 0; i < vehicles.Count; i++)
                {
                    vehicledtos.Add(
                        new VehicleDTO()
                        {
                            Id = vehicles[i].Id,
                            CategoryId = vehicles[i].CategoryId,
                            Brand = vehicles[i].Brand,
                            Model = vehicles[i].Model,
                            Description = vehicles[i].Description,
                            Price = vehicles[i].Price,
                            Horsepower = vehicles[i].Horsepower,
                            NumberOfSeats = vehicles[i].NumberOfSeats,
                            Mileage = vehicles[i].Mileage
                        });
                }

                return vehicledtos;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message + $"[{nameof(VehicleService)}:{nameof(GetVehicles)}]");
            }
        }

        public async Task<CategoryDTO> GetCategory(string id)
        {
            try
            {
                Vehicle vehicle = await _vehicleRepository.GetById(id);
                VehicleCategory category = await _categoryRepository.GetById(vehicle.CategoryId);
                
                return new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message + $"[{nameof(VehicleService)}:{nameof(GetCategory)}]");
            }
        }
    }
}
