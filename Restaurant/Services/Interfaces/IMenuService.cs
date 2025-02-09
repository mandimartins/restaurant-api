using Restaurant.Data.Models;
using Restaurant.Data.ViewModel;
using Restaurant.Data.ViewModels;

namespace Restaurant.Services.Interfaces
{
    public interface IMenuService
    {
        Task<Menu> GetAsyncAsNoTracking(int id);
        Task<(int totalRows, IList<Menu> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter);
        Task<Menu> AddAsync(MenuViewModel category);
        Task<Menu> UpdateAsync(MenuViewModel category);
        Task<Menu> DeleteAsync(int id);
        Task<IList<Menu>> GetAllAsyncAsNoTracking();
    }
}
