using Restaurant.Data.Models;
using Restaurant.Data.ViewModel;
using Restaurant.Data.ViewModels;

namespace Restaurant.Services.Interfaces
{
    public interface IMenuItemService
    {
        Task<MenuItem> GetAsyncAsNoTracking(int id);
        Task<(int totalRows, IList<MenuItem> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter);
        Task<MenuItem> AddAsync(MenuItemViewModel category);
        Task<MenuItem> UpdateAsync(MenuItemViewModel category);
        Task<MenuItem> DeleteAsync(int id);
        Task<IList<MenuItem>> GetAllAsyncAsNoTracking();

        Task<IList<MenuItem>> GetAllMenuItensByIdMenuAsNoTracking(int idMenu);
    }
}
