using Restaurant.Data.Models;
using Restaurant.Data.ViewModels;

namespace Restaurant.Repositories.Interfaces
{
    public interface IMenuRepository
    {
        Task<Menu> AddAsync(Menu category);
        Task<Menu> GetAsyncAsNoTracking(int Id);
        Task<(int TotalRows, IList<Menu> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter);
        Task<Menu> DeleteAsync(int id);
    }
}
