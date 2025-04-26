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
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly INotificationHandler _notificationHandler;
        private readonly IMapper _mapper;

        public MenuItemService(
            IMenuItemRepository menuItemRepository,
            INotificationHandler notificationHandler,
            IMapper mapper)
        {
            _menuItemRepository = menuItemRepository;
            _notificationHandler = notificationHandler;
            _mapper = mapper;
        }

        public async Task<MenuItem> AddAsync(MenuItemViewModel menuDTO)
        {
            if (!menuDTO.Validate().Notify(_notificationHandler))
                return new MenuItem();

            var menu = _mapper.Map<MenuItem>(menuDTO);

            return await _menuItemRepository.AddAsync(menu);
        }

        public async Task<MenuItem> DeleteAsync(int id)
        {
            return await _menuItemRepository.DeleteAsync(id);
        }

        public async Task<MenuItem> GetAsyncAsNoTracking(int Id)
        {
            return await _menuItemRepository.GetAsyncAsNoTracking(Id);
        }

        public async Task<(int totalRows, IList<MenuItem> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter)
        {
            return await _menuItemRepository.GetAllAsyncAsNoTracking(filter);
        }

        public Task<MenuItem> UpdateAsync(MenuItemViewModel menu)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<MenuItem>> GetAllAsyncAsNoTracking()
        {
            return await _menuItemRepository.GetAllAsyncAsNoTracking();
        }

        public async Task<IList<MenuItem>> GetAllMenuItensByIdMenuAsNoTracking(int idMenu)
        {
            return await _menuItemRepository.GetAllMenuItensByIdMenuAsNoTracking(idMenu);
        }

    }
}
