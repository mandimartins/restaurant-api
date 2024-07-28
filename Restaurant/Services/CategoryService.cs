using AutoMapper;
using Restaurant.Data.ViewModel;
using Restaurant.Data.Models;
using Restaurant.Repositories.Interfaces;
using Restaurant.Services.Interfaces;
using Restaurant.Utilities.ExtensionMethods;
using Restaurant.Utilities.NotificationPattern;
using Restaurant.Data.ViewModels;

namespace Restaurant.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly INotificationHandler _notificationHandler;
        private readonly IMapper _mapper;

        public CategoryService(
            ICategoryRepository categoryRepository,
            INotificationHandler notificationHandler,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _notificationHandler = notificationHandler;
            _mapper = mapper;
        }

        public async Task<Category> AddAsync(CategoryViewModel categoryDTO)
        {
            if (!categoryDTO.Validate().Notify(_notificationHandler))
                return new Category();

            var category = _mapper.Map<Category>(categoryDTO);

            return await _categoryRepository.AddAsync(category);
        }

        public async Task<Category> DeleteAsync(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }

        public async Task<Category> GetAsyncAsNoTracking(int Id)
        {
            return await _categoryRepository.GetAsyncAsNoTracking(Id);
        }

        public async Task<(int totalRows, IList<Category> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter)
        {
            return await _categoryRepository.GetAllAsyncAsNoTracking(filter);
        }

        public Task<Category> UpdateAsync(CategoryViewModel category)
        {
            throw new NotImplementedException();
        }
    }
}
