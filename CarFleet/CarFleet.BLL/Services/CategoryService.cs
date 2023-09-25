using CarFleet.DAL.Entities;
using CarFleet.DAL.Repositories.Interfaces;

namespace CarFleet.BLL.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository<VehicleCategory> _categoryRepository;

        public CategoryService(ICategoryRepository<VehicleCategory> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<VehicleCategory> GetCategoryById(string id)
        {
            try
            {
                return await _categoryRepository.GetById(id);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message + $"[{nameof(CategoryService)}:{nameof(GetCategoryById)}]");
            }
        }
    }
}
