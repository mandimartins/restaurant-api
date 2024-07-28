using Restaurant.Data.Models;
using Restaurant.Data.ViewModels;

namespace Restaurant.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddAsync(Category category);
        Task<Category> GetAsyncAsNoTracking(int Id);
        Task<(int TotalRows, IList<Category> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter);
        Task<Category> DeleteAsync(int id);
    }
}
