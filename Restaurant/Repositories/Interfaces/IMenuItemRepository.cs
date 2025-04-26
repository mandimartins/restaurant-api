using Restaurant.Data.Models;
using Restaurant.Data.ViewModels;

namespace Restaurant.Repositories.Interfaces
{
    public interface IMenuItemRepository
    {
        Task<MenuItem> AddAsync(MenuItem menuItem);
        Task<MenuItem> GetAsyncAsNoTracking(int Id);
        Task<(int TotalRows, IList<MenuItem> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter);
        Task<MenuItem> DeleteAsync(int id);
        Task<IList<MenuItem>> GetAllAsyncAsNoTracking();
        Task<IList<MenuItem>> GetAllMenuItensByIdMenuAsNoTracking(int idMenu);
    }
}
