using AutoMapper;
using Restaurant.Data.Models;
using Restaurant.Data.ViewModel;
using Restaurant.Data.ViewModels;
using Restaurant.Repositories.Interfaces;
using Restaurant.Services.Interfaces;
using Restaurant.Utilities.ExtensionMethods;
using Restaurant.Utilities.NotificationPattern;

namespace Restaurant.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly INotificationHandler _notificationHandler;
        private readonly IMapper _mapper;

        public MenuService(
            IMenuRepository menuRepository,
            INotificationHandler notificationHandler,
            IMapper mapper)
        {
            _menuRepository = menuRepository;
            _notificationHandler = notificationHandler;
            _mapper = mapper;
        }

        public async Task<Menu> AddAsync(MenuViewModel menuDTO)
        {
            if (!menuDTO.Validate().Notify(_notificationHandler))
                return new Menu();

            var menu = _mapper.Map<Menu>(menuDTO);

            return await _menuRepository.AddAsync(menu);
        }

        public async Task<Menu> DeleteAsync(int id)
        {
            return await _menuRepository.DeleteAsync(id);
        }

        public async Task<Menu> GetAsyncAsNoTracking(int Id)
        {
            return await _menuRepository.GetAsyncAsNoTracking(Id);
        }

        public async Task<(int totalRows, IList<Menu> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter)
        {
            return await _menuRepository.GetAllAsyncAsNoTracking(filter);
        }

        public Task<Menu> UpdateAsync(MenuViewModel menu)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Menu>> GetAllAsyncAsNoTracking()
        {
            return await _menuRepository.GetAllAsyncAsNoTracking();
        }
    }
}
